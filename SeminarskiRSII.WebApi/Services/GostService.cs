using AutoMapper;
using SeminarskiRSII.Model.Requests;
using SeminarskiRSII.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
    public class GostService:IGostService
    {
        private readonly SeminarskiRSIIBazaContext _context;
        private readonly IMapper _mapper;

        public GostService(SeminarskiRSIIBazaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.Gost> get(GostiSearchRequest search)
        {
            //var list = _context.Gost.ToList();      // Normlni get bez uslova za pretragom
            //return _mapper.Map<List<Model.Gost>>(list);
            var query = _context.Gost.Include(g => g.Grad).AsQueryable();
            if (search != null)
            {
                if (search.gradID.HasValue)
                {
                    query = query.Where(v => v.GradId == search.gradID.Value);
                }
            }
            if (!string.IsNullOrWhiteSpace(search?.ime))
            {
                query = query.Where(x => x.Ime.StartsWith(search.ime));
            }
            if (!string.IsNullOrWhiteSpace(search?.prezime))
            {
                query = query.Where(x => x.Prezime.StartsWith(search.prezime));
            }
            var list = query.ToList();
            return _mapper.Map<List<Model.Gost>>(list);
        }

        public Model.Gost getById(int id)
        {
            var entity = _context.Gost.Find(id);
            return _mapper.Map<Model.Gost>(entity);
        }

        public Model.Gost Insert(GostiInsertRequest requst)
        {
            var entity = _mapper.Map<Database.Gost>(requst);
            if (requst.Lozinka != requst.PotvrdiLozinku)
            {
                throw new UserException("Lozinke se ne podudaraju");
            }
            entity.LozinkaSalt = Util.PasswordGenerator.GenerateSalt();
            entity.LozinkaHash = Util.PasswordGenerator.GenerateHash(requst.Lozinka, entity.LozinkaSalt);
            _context.Gost.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Gost>(entity);
        }

        public Model.Gost Update(int id, GostiInsertRequest requst)
        {
            var entity = _context.Gost.Find(id);
            _mapper.Map(requst, entity);
            _context.SaveChanges();
            return _mapper.Map<Model.Gost>(entity);
        }
        
    }
}
