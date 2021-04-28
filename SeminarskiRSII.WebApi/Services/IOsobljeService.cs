using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
   public interface IOsobljeService
    {
        List<Model.Osoblje> get(OsobljeSearchRequest search);
        Model.Osoblje getByID(int id);
        Model.Osoblje Insert(OsobljeInsertRequest insert);
        Model.Osoblje Update(int id, OsobljeInsertRequest update);
    }
}
