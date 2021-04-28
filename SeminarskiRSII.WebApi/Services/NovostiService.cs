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
    public class NovostiService:INovostiService
    {
        private readonly SeminarskiRSIIBazaContext _context;
        private readonly IMapper _mapper;

        public NovostiService(SeminarskiRSIIBazaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Novosti> get(NovostiSearchRequest search)
        {
            var query = _context.Novosti.Include(o => o.Osoblje).AsQueryable();
            if (search != null)
            {
                if (search.OsobljeId.HasValue)
                {
                    query = query.Where(o => o.OsobljeId == search.OsobljeId);
                }
            }
            if (!string.IsNullOrWhiteSpace(search?.Naslov))
            {
                query = query.Where(n => n.Naslov.StartsWith(search.Naslov));
            }
            if (!string.IsNullOrWhiteSpace(search?.Sadrzaj))
            {
                query = query.Where(s => s.Sadrzaj.StartsWith(search.Sadrzaj));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Novosti>>(list);
        }

        public Model.Novosti getByID(int ID)
        {
            var id = _context.Novosti.Find(ID);
            return _mapper.Map<Model.Novosti>(id);

        }

        public Model.Novosti Insert(NovostiInsertRequest insert)
        {
            var dodaj = _mapper.Map<Database.Novosti>(insert);
            _context.Novosti.Add(dodaj);
            _context.SaveChanges();
            return _mapper.Map<Model.Novosti>(dodaj);
        }

        public Model.Novosti Update(int ID, NovostiInsertRequest update)
        {
            var entity = _context.Novosti.Find(ID);
            _mapper.Map(update, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Novosti>(entity);
        }
    }
}
