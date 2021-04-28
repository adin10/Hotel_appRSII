using AutoMapper;
using SeminarskiRSII.Model;
using SeminarskiRSII.Model.Requests;
using SeminarskiRSII.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
    public class GostiNotifikacijeService : IGostiNotifikacijeService
    {
        private readonly SeminarskiRSIIBazaContext _context;
        private readonly IMapper _mapper;
        public GostiNotifikacijeService(SeminarskiRSIIBazaContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Model.GostiNotifikacije> get(GostiNotifikacijeSearchRequest search)
        {
            var query = _context.GostiNotifikacije.Include(x => x.Gost).Include(l => l.Notifikacije).AsQueryable();

            if (search != null)
            {
                if (search.PutnikId.HasValue)
                {
                    query = query.Where(l => l.GostId == search.PutnikId.Value);
                }

                if (search.NotifikacijaId.HasValue)
                {
                    query = query.Where(l => l.NotifikacijaId == search.NotifikacijaId.Value);
                }

            }

            var lista = query.ToList();

            return _mapper.Map<List<Model.GostiNotifikacije>>(lista);
        }
    
    }
}
