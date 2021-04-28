using AutoMapper;
using SeminarskiRSII.Model.Requests;
using SeminarskiRSII.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
    public class DrzavaService:IDrzavaService
    {
        private readonly SeminarskiRSIIBazaContext _context;
        private readonly IMapper _mapper;
        public DrzavaService(SeminarskiRSIIBazaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Drzava> get(DrzavaSearchRequest request)
        {
            var query = _context.Drzava.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request?.naziv))
            {
                query = query.Where(x => x.Naziv.StartsWith(request.naziv));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Drzava>>(list);
        }

        public Model.Drzava GetByID(int id)
        {
            var entity = _context.Drzava.Find(id);
            return _mapper.Map<Model.Drzava>(entity);
        }

        public Model.Drzava Insert(DrzavaSearchRequest insert)
        {
            var entity = _mapper.Map<Database.Drzava>(insert);
            _context.Drzava.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Drzava>(entity);
        }

        public Model.Drzava Update(int id, DrzavaSearchRequest update)
        {
            var entity = _context.Drzava.Find(id);
            _mapper.Map(update, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Drzava>(entity);
        }
    }
}
