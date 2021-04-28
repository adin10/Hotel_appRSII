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
    public class NotifikacijaService : BaseCRUDService<Model.Notifikacije, NotifikacijeSearchRequest, Database.Notifikacije, NotifikacijeInsertRequest, NotifikacijeInsertRequest>
    {
        public NotifikacijaService(SeminarskiRSIIBazaContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override List<Model.Notifikacije> get(NotifikacijeSearchRequest search)
        {
            var query = _context.Notifikacije.Include(x => x.Novost).AsQueryable();

            if (search != null)
            {
                if (!string.IsNullOrWhiteSpace(search.Naslov))
                {
                    query = query.Where(l => l.Naslov.StartsWith(search.Naslov));
                }

                if (search.NovostId.HasValue)
                {
                    query = query.Where(l => l.NovostId == search.NovostId.Value);
                }
            }

            var lista = query.OrderByDescending(l => l.DatumSlanja).ToList();

            return _mapper.Map<List<Model.Notifikacije>>(lista);

        }
    }
}