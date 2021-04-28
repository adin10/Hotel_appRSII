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
    public class GradService:IGradService
    {
        private readonly SeminarskiRSIIBazaContext _context;
        private readonly IMapper _mapper;
        public GradService(SeminarskiRSIIBazaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.Grad Delete(int id)
        {
            var entity = _context.Grad.Find(id);
            _context.Grad.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Grad>(entity);
        }

        public List<Model.Grad> get(GradSearchRequest search)
        {
            var query = _context.Grad.Include(g => g.Drzava).AsQueryable();
            if (search != null)
            {
                if (search.DrzavaId.HasValue)
                {
                    query = query.Where(v => v.DrzavaId == search.DrzavaId.Value);
                }
            }
            if (!string.IsNullOrWhiteSpace(search?.NazivGrada))
            {
                query = query.Where(x => x.NazivGrada.StartsWith(search.NazivGrada));
            }

            var list = query.ToList();
            return _mapper.Map<List<Model.Grad>>(list);
        }

        public Model.Grad GetByID(int id)
        {
            var entity = _context.Grad.Find(id);
            return _mapper.Map<Model.Grad>(entity);
        }

        public Model.Grad Insert(GradInsertRequest insert)
        {
            var entity = _mapper.Map<Database.Grad>(insert);
            _context.Grad.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Grad>(entity);
        }

        public Model.Grad Update(int id, GradInsertRequest update)
        {
            var entity = _context.Grad.Find(id);
            _mapper.Map(update, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Grad>(entity);
        }
       
    }
}
