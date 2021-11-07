using AutoMapper;
using SeminarskiRSII.Model.Requests;
using SeminarskiRSII.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
    public class RezervacijaService:IRezervacijaService
    {
        private readonly SeminarskiRSIIBazaContext _context;
        private readonly IMapper _mapper;

        public RezervacijaService(SeminarskiRSIIBazaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.Rezervacija Delete(int id)
        {
            var entity = _context.Rezervacija.Find(id);
            _context.Rezervacija.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Rezervacija>(entity);
        }

        public List<Model.Rezervacija> get(RezervacijaSearchRequest search)
        {

            var query = _context.Rezervacija.Include(r => r.Gost).Include(r => r.Soba).AsQueryable();
            if (search != null)
            {
                if (search.BrojSobe.HasValue)
                {
                    query = query.Where(r => r.Soba.BrojSobe == search.BrojSobe.Value);
                }
                if (search.gostID.HasValue)
                {
                    query = query.Where(r => r.GostId == search.gostID);
                }
            }
            if (!string.IsNullOrWhiteSpace(search?.KorisnickoIme))
            {
                query = query.Where(x => x.Gost.KorisnickoIme.Equals(search.KorisnickoIme));
            }
            var list = query.ToList();
            //var list = _context.Rezervacija.Include(r => r.Gost).Include(r => r.Soba).ToList();
            return _mapper.Map<List<Model.Rezervacija>>(list);
        }

        public Model.Rezervacija getByID(int id)
        {
            var entity = _context.Rezervacija.Find(id);
            return _mapper.Map<Model.Rezervacija>(entity);
        }

        public Model.Rezervacija Insert(RezervacijaInsertRequest insert)
        {
            var entity = _mapper.Map<Database.Rezervacija>(insert);
            _context.Rezervacija.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Rezervacija>(entity);

        }

        public Model.Rezervacija Update(int id, RezervacijaInsertRequest update)
        {
            var entity = _context.Rezervacija.Find(id);
            _mapper.Map(update, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Rezervacija>(entity);
        }
    }
}
