using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
   public interface ISobaOsobljeService
    {
        List<Model.SobaOsoblje> get();
        Model.SobaOsoblje getById(int id);
        Model.SobaOsoblje Insert(SobaOsobljeInsertRequest insert);
        Model.SobaOsoblje Update(int id, SobaOsobljeInsertRequest insert);
        Model.SobaOsoblje Delete(int id);
    }
}
