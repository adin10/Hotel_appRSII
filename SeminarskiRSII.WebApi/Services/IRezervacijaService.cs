using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
   public interface IRezervacijaService
    {
        List<Model.Rezervacija> get(/*RezervacijaSearchRequest search*/);
        Model.Rezervacija getByID(int id);
        Model.Rezervacija Insert(RezervacijaInsertRequest insert);
        Model.Rezervacija Update(int id, RezervacijaInsertRequest update);
    }
}
