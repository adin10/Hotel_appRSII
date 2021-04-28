using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
   public interface INovostiService
    {
        List<Model.Novosti> get(NovostiSearchRequest search);
        Model.Novosti getByID(int ID);
        Model.Novosti Insert(NovostiInsertRequest insert);
        Model.Novosti Update(int ID, NovostiInsertRequest update);
    }
}
