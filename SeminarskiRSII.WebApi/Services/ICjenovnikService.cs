using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
    public interface ICjenovnikService
    {
        List<Model.Cjenovnik> get();
        Model.Cjenovnik getById(int id);
        Model.Cjenovnik Insert(CijenaInsertRequest insert);
        Model.Cjenovnik Update(int id, CijenaInsertRequest update);
    }
}
