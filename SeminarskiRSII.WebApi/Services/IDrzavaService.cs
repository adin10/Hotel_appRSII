using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
   public interface IDrzavaService
    {
        List<Model.Drzava> get(DrzavaSearchRequest request);
        Model.Drzava GetByID(int id);
        Model.Drzava Insert(DrzavaSearchRequest insert);
        Model.Drzava Update(int id, DrzavaSearchRequest update);
    }
}
