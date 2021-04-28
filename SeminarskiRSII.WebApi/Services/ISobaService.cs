using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
   public interface ISobaService
    {
        List<Model.Soba> get(SobaSearchRequest search);
        Model.Soba getByID(int id);
        Model.Soba Insert(SobaInsertRequest insert);
        Model.Soba Update(int id, SobaInsertRequest update);
        Model.Soba Delete(int id);
    }
}
