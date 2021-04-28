using AutoMapper;
using SeminarskiRSII.Model.Requests;
using SeminarskiRSII.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public List<Model.Osoblje> get(OsobljeSearchRequest search)
        {
            var query = _context.Osoblje.Include("OsobljeUloge.Osoblje").AsQueryable();


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
            var entity = _context.Osoblje.Find(id);
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
            entity.LozinkaSalt = Util.PasswordGenerator.GenerateSalt();
            entity.LozinkaHash = Util.PasswordGenerator.GenerateHash(insert.Lozinka, entity.LozinkaSalt);
            _context.Osoblje.Add(entity);
            _context.SaveChanges();
            //foreach (var item in insert.Uloge)
            //{
            //    var korisniciUloga = new Database.KorisniciUloge();
            //    korisniciUloga.DatumIzmjene = DateTime.Now;
            //    korisniciUloga.KorisnikId =entity.Id;
            //    korisniciUloga.UlogaId = item;
            //    _context.KorisniciUloge.Add(korisniciUloga);
            //}
            return _mapper.Map<Model.Osoblje>(entity);

        }

        public Model.Osoblje Update(int id, OsobljeInsertRequest update)
        {
            var entity = _context.Osoblje.Find(id);
            _mapper.Map(update, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Osoblje>(entity);
        }
    }
}
