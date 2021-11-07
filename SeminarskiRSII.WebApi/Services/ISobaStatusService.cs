using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
   public interface ISobaStatusService
    {
        List<Model.SobaStatus> get();
        Model.SobaStatus getByID(int id);
        Model.SobaStatus Insert(SobaStatusInsertRequest insert);
        Model.SobaStatus Update(int id, SobaStatusInsertRequest update);

        Model.SobaStatus Delete(int id);
    }
}
