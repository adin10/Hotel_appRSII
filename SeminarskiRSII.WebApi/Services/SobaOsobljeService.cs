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
    public class SobaOsobljeService:ISobaOsobljeService
    {
        private readonly SeminarskiRSIIBazaContext _context;
        private readonly IMapper _mapper;

        public SobaOsobljeService(SeminarskiRSIIBazaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.SobaOsoblje Delete(int id)
        {
            var entity = _context.SobaOsoblje.Find(id);
            _context.SobaOsoblje.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.SobaOsoblje>(entity);
        }

        public List<Model.SobaOsoblje> get()
        {
            var list = _context.SobaOsoblje.Include(s => s.Soba).Include(o => o.Osoblje).ToList();
            return _mapper.Map<List<Model.SobaOsoblje>>(list);
        }

        public Model.SobaOsoblje getById(int id)
        {
            var entity = _context.SobaOsoblje.Find(id);
            return _mapper.Map<Model.SobaOsoblje>(entity);
        }

        public Model.SobaOsoblje Insert(SobaOsobljeInsertRequest insert)
        {
            var entity = _mapper.Map<Database.SobaOsoblje>(insert);
            _context.SobaOsoblje.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.SobaOsoblje>(entity);
        }

        public Model.SobaOsoblje Update(int id, SobaOsobljeInsertRequest insert)
        {
            var entity = _context.SobaOsoblje.Find(id);
            _mapper.Map(insert, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.SobaOsoblje>(entity);
        }
    }
}
