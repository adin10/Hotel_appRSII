using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
    public interface IVrstaOsobljaService
    {
        List<Model.VrstaOsoblja> get(/*VrstaOsobljaSearchRequest request*/);
        Model.VrstaOsoblja getByID(int id);
        Model.VrstaOsoblja Insert(VrstaOsobljaInsertRequest insert);
        Model.VrstaOsoblja Update(int id, VrstaOsobljaInsertRequest update);
    }
}
