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
    public class RecenzijaService:IRecenzijaService
    {
        private readonly SeminarskiRSIIBazaContext _context;
        private readonly IMapper _mapper;

        public RecenzijaService(SeminarskiRSIIBazaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Recenzija> get(RecenzijaSearchRequest search)
        {
            var query = _context.Recenzija.Include(r => r.Gost).Include(r=>r.Soba).AsQueryable();
            if (search != null)
            {
                if (search.ocjena.HasValue)
                {
                    query = query.Where(r => r.Ocjena == search.ocjena.Value);
                }
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Recenzija>>(list);
        }

        public Model.Recenzija getByID(int id)
        {
            var entity = _context.Recenzija.Find(id);
            return _mapper.Map<Model.Recenzija>(entity);
        }

        public Model.Recenzija Insert(RecenzijaInsertRequest insert)
        {
            var entity = _mapper.Map<Database.Recenzija>(insert);
            _context.Recenzija.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Recenzija>(entity);
        }

        public Model.Recenzija Update(int id, RecenzijaInsertRequest update)
        {
            var entity = _context.Recenzija.Find(id);
            _mapper.Map(update, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Recenzija>(entity);
        }
    }
}
