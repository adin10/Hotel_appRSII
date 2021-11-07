using AutoMapper;
using SeminarskiRSII.Model.Requests;
using SeminarskiRSII.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
    public class SobaStatusService:ISobaStatusService
    {
        private readonly SeminarskiRSIIBazaContext _context;
        private readonly IMapper _mapper;

        public SobaStatusService(SeminarskiRSIIBazaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.SobaStatus Delete(int id)
        {
            var entity = _context.SobaStatus.Find(id);
            _context.SobaStatus.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.SobaStatus>(entity);
        }

        public List<Model.SobaStatus> get()
        {
            var list = _context.SobaStatus.ToList();
            return _mapper.Map<List<Model.SobaStatus>>(list);
        }

        public Model.SobaStatus getByID(int id)
        {
            var entitiy = _context.SobaStatus.Find(id);
            return _mapper.Map<Model.SobaStatus>(entitiy);
        }

        public Model.SobaStatus Insert(SobaStatusInsertRequest insert)
        {
            var entity = _mapper.Map<Database.SobaStatus>(insert);
            _context.SobaStatus.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.SobaStatus>(entity);
        }

        public Model.SobaStatus Update(int id, SobaStatusInsertRequest update)
        {
            var entity = _context.SobaStatus.Find(id);
            _mapper.Map(update, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.SobaStatus>(entity);
        }
    }
}
