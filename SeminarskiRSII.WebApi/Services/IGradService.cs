using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
    public interface IGradService
    {
        List<Model.Grad> get(GradSearchRequest request);
        Model.Grad GetByID(int id);
        Model.Grad Insert(GradInsertRequest insert);
        Model.Grad Update(int id, GradInsertRequest update);

        Model.Grad Delete(int id);
    }
}
