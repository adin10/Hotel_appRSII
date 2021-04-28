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
    public class CjenovnikService:ICjenovnikService
    {
        private readonly SeminarskiRSIIBazaContext _context;
        private readonly IMapper _mapper;

        public CjenovnikService(SeminarskiRSIIBazaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Cjenovnik> get()
        {
            var list = _context.Cjenovnik.Include(s => s.Soba).ToList();
            return _mapper.Map<List<Model.Cjenovnik>>(list);
        }

        public Model.Cjenovnik getById(int id)
        {
            var entity = _context.Cjenovnik.Find(id);
            return _mapper.Map<Model.Cjenovnik>(entity);
        }

        public Model.Cjenovnik Insert(CijenaInsertRequest insert)
        {
            var dodavanje = _mapper.Map<Database.Cjenovnik>(insert);
            _context.Cjenovnik.Add(dodavanje);
            _context.SaveChanges();
            return _mapper.Map<Model.Cjenovnik>(dodavanje);

        }

        public Model.Cjenovnik Update(int id, CijenaInsertRequest update)
        {
            var entity = _context.Cjenovnik.Find(id);
            _mapper.Map(update, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Cjenovnik>(entity);
        }
    }
}
