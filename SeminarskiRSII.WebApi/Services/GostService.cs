using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SeminarskiRSII.Model.Requests;
using SeminarskiRSII.WebApi.Database;
using SeminarskiRSII.WebAPI.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
    public class GostService:IGostService
    {
        private readonly SeminarskiRSIIBazaContext _context;
        private readonly IMapper _mapper;

        public GostService(SeminarskiRSIIBazaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.Gost AuthenticirajGosta(string username, string pass)
        {
            var user = _context.Gost.Where(x => x.KorisnickoIme == username).FirstOrDefault();

            if (user != null)
            {
                var newHash =Util.PasswordGenerator.GenerateHash(user.LozinkaSalt, pass);

                if (newHash == user.LozinkaHash)
                {
                    return _mapper.Map<Model.Gost>(user);
                }
            }
            return null;
        }

        //__________________________________________________________________

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

        //_____________________________________________________________________

        public List<Model.Gost> get(GostiSearchRequest search)
        {
            //var list = _context.Gost.ToList();      // Normlni get bez uslova za pretragom
            //return _mapper.Map<List<Model.Gost>>(list);
            var query = _context.Gost.Include(g => g.Grad).AsQueryable();
            if (search != null)
            {
                if (search.gradID.HasValue)
                {
                    query = query.Where(v => v.GradId == search.gradID.Value);
                }
            }
            if (!string.IsNullOrWhiteSpace(search?.ime))
            {
                query = query.Where(x => x.Ime.StartsWith(search.ime));
            }
            if (!string.IsNullOrWhiteSpace(search?.prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(search.prezime));
            }
            if (!string.IsNullOrWhiteSpace(search?.KorisnickoIme))
            {
                query = query.Where(x => x.KorisnickoIme.Equals(search.KorisnickoIme));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Gost>>(list);
        }

        public Model.Gost getById(int id)
        {
            var entity = _context.Gost.Include(a=>a.Grad).FirstOrDefault(x=>x.Id==id);
            return _mapper.Map<Model.Gost>(entity);

            
        }

        public Model.Gost Insert(GostiInsertRequest requst)
        {
            var entity = _mapper.Map<Database.Gost>(requst);
            if (requst.Lozinka != requst.PotvrdiLozinku)
            {
                throw new UserException("Lozinke se ne podudaraju");
            }
            entity.LozinkaSalt = Util.PasswordGenerator.GenerateSalt();
            entity.LozinkaHash = Util.PasswordGenerator.GenerateHash(entity.LozinkaSalt,requst.Lozinka);
            _context.Gost.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Gost>(entity);
        }

        public Model.Gost Update(int id, GostiInsertRequest request)
        {
            var entity = _context.Gost.Find(id);
            _context.Gost.Attach(entity);
            _context.Gost.Update(entity);
            if (!string.IsNullOrWhiteSpace(request.Lozinka))
            {
                if (request.Lozinka != request.PotvrdiLozinku)
                {
                    throw new Exception("Passwordi se ne slažu");
                }

                entity.LozinkaSalt =Util.PasswordGenerator.GenerateSalt();
                entity.LozinkaHash =Util.PasswordGenerator.GenerateHash(entity.LozinkaSalt, request.Lozinka);
            }
            _mapper.Map(request, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Gost>(entity);
        }
        
    }
}
