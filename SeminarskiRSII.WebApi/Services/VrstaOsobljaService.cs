using AutoMapper;
using SeminarskiRSII.Model.Requests;
using SeminarskiRSII.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
    public class VrstaOsobljaService:IVrstaOsobljaService
    {
        private readonly SeminarskiRSIIBazaContext _context;
        private readonly IMapper _mapper;
        public VrstaOsobljaService(SeminarskiRSIIBazaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.VrstaOsoblja> get(/*VrstaOsobljaSearchRequest request*/)
        {
            //var query = _context.VrstaOsoblja.AsQueryable();
            //if (!string.IsNullOrWhiteSpace(request.Pozicija))
            //{
            //    query = query.Where(p => p.Pozicija.StartsWith(request.Pozicija));
            //}
            //var list = query.ToList();
            var list = _context.VrstaOsoblja.ToList();
            return _mapper.Map<List<Model.VrstaOsoblja>>(list);
        }

        public Model.VrstaOsoblja getByID(int id)
        {
            var entity = _context.VrstaOsoblja.Find(id);
            return _mapper.Map<Model.VrstaOsoblja>(entity);
        }

        public Model.VrstaOsoblja Insert(VrstaOsobljaInsertRequest insert)
        {
            var entity = _mapper.Map<Database.VrstaOsoblja>(insert);
            _context.VrstaOsoblja.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.VrstaOsoblja>(entity);
        }

        public Model.VrstaOsoblja Update(int id, VrstaOsobljaInsertRequest update)
        {
            var entity = _context.VrstaOsoblja.Find(id);
            _mapper.Map(update, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.VrstaOsoblja>(entity);
        }
    }
}
