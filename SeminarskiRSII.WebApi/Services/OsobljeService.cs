using AutoMapper;
using SeminarskiRSII.Model.Requests;
using SeminarskiRSII.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace SeminarskiRSII.WebApi.Services
{
    public class OsobljeService : IOsobljeService
    {
        private readonly SeminarskiRSIIBazaContext _context;
        private readonly IMapper _mapper;

        public OsobljeService(SeminarskiRSIIBazaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.Osoblje Authenticiraj(string username, string pass)
        {
            var user = _context.Osoblje.Include(x=>x.OsobljeUloge).FirstOrDefault(x => x.KorisnickoIme == username);

            if (user != null)
            {
                var newHash = GenerateHash(user.LozinkaSalt, pass);

                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Osoblje>(user);
                }
            }
            return null;
        }
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        public List<Model.Osoblje> get(OsobljeSearchRequest search)
        {
            var query = _context.Osoblje.Include(x=>x.OsobljeUloge).AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.ime))
            {
                query = query.Where(o => o.Ime.StartsWith(search.ime));
            }
            if (!string.IsNullOrWhiteSpace(search?.prezime))
            {
                query = query.Where(o => o.Prezime.StartsWith(search.prezime));
            }
            if (!string.IsNullOrWhiteSpace(search?.korisnickoIme))
            {
                query = query.Where(l => l.KorisnickoIme.StartsWith(search.korisnickoIme));
            }

            var list = query.ToList();
            return _mapper.Map<List<Model.Osoblje>>(list);
        }

        public Model.Osoblje getByID(int id)
        {
            var entity = _context.Osoblje.Include(x=>x.OsobljeUloge).Where(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            {
                throw new UserException("Niije pronadjen korisnik!");
            }
            return _mapper.Map<Model.Osoblje>(entity);
        }

        public Model.Osoblje Insert(OsobljeInsertRequest insert)
        {
            var entity = _mapper.Map<Database.Osoblje>(insert);
            if (insert.Lozinka != insert.PotvrdiLozinku)
            {
                throw new UserException("Lozinke se ne podudaraju");
            }
            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash =GenerateHash(insert.Lozinka, entity.LozinkaSalt);
            _context.Osoblje.Add(entity);
            _context.SaveChanges();
            foreach (var uloga in insert.Uloge)
            {
                Database.OsobljeUloge korisniciUloge = new Database.OsobljeUloge{

                DatumIzmjene = DateTime.Now,
                OsobljeId = entity.Id,
                VrstaOsobljaId = uloga
                };
                _context.OsobljeUloge.Add(korisniciUloge);
            }
            return _mapper.Map<Model.Osoblje>(entity);

 

        }

        public Model.Osoblje Update(int id, OsobljeInsertRequest request)
        {
            var entity = _context.Osoblje.Find(id);
            _context.Osoblje.Attach(entity);
            _context.Osoblje.Update(entity);
            //____________________________________________________________
            var korisnickeUloge = _context.OsobljeUloge.Where(x => x.OsobljeId == id).ToList();
            foreach(var item in korisnickeUloge)
            {
                _context.OsobljeUloge.Remove(item);
            }
            foreach(var uloga in request.Uloge)
            {
                Database.OsobljeUloge korisniciUloge = new Database.OsobljeUloge
                {
                    OsobljeId = entity.Id,
                    VrstaOsobljaId = uloga,
                    DatumIzmjene = DateTime.Now
                };
                _context.OsobljeUloge.Add(korisniciUloge);
            }
            _context.SaveChanges();
            //______________________________________________________
            if (!string.IsNullOrWhiteSpace(request.Lozinka))
            {
                if (request.Lozinka != request.PotvrdiLozinku)
                {
                    throw new Exception("Passwordi se ne slazu");
                }
                entity.LozinkaSalt =GenerateSalt();
                entity.LozinkaHash =GenerateHash(entity.LozinkaSalt, request.Lozinka);
            }
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Osoblje>(entity);
        }
    }
}
