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
    public class SobaService:ISobaService
    {
        private readonly SeminarskiRSIIBazaContext _context;
        private readonly IMapper _mapper;

        public SobaService(SeminarskiRSIIBazaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Model.Soba Delete(int id)
        {
            var entity = _context.Soba.Find(id);
            _context.Soba.Remove(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Soba>(entity);
        }

        public List<Model.Soba> get(SobaSearchRequest search)
        {
            var query = _context.Soba.Include(s => s.SobaStatus).AsQueryable();
            if (search != null)
            {
                if (search.SobaStatusId.HasValue)
                {
                    query = query.Where(s => s.SobaStatusId == search.SobaStatusId.Value);
                }

                if (search.BrojSobe.HasValue)
                {
                    query = query.Where(l => l.BrojSobe == search.BrojSobe.Value);
                }

            }

            var list = query.ToList();
            return _mapper.Map<List<Model.Soba>>(list);
        }

        public Model.Soba getByID(int id)
        {
            var entity = _context.Soba.Find(id);
            return _mapper.Map<Model.Soba>(entity);
        }

        public Model.Soba Insert(SobaInsertRequest insert)
        {
            var entity = _mapper.Map<Database.Soba>(insert);
            _context.Soba.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Soba>(entity);
        }

        public Model.Soba Update(int id, SobaInsertRequest update)
        {
            var entity = _context.Soba.Find(id);
            _mapper.Map(update, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Soba>(entity);
        }

    }
    //public class SobaService : BaseCRUDService<Model.Soba, SobaSearchRequest,Database.Soba, SobaInsertRequest, SobaInsertRequest>
    //{
    //    public SobaService(HotelProbaContext context, IMapper mapper) : base(context, mapper)
    //    {
    //    }
    //    public override List<Model.Soba> get(SobaSearchRequest search)
    //    {
    //        var query = _context.Set<Database.Soba>().AsQueryable();
    //        if (search != null)
    //        {
    //            //if (search.SobaStatusId.HasValue)
    //            //{
    //            //    query = query.Where(s => s.SobaStatusId == search.SobaStatusId.Value);
    //            //}

    //            if (search.BrojSobe.HasValue)
    //            {
    //                query = query.Where(l => l.BrojSobe == search.BrojSobe.Value);
    //            }

    //        }

    //        var list = query.ToList();
    //        return _mapper.Map<List<Model.Soba>>(list);
    //    }
    //}
}

