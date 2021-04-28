using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
   public interface IRecenzijaService
    {
        List<Model.Recenzija> get(RecenzijaSearchRequest search);
        Model.Recenzija getByID(int id);
        Model.Recenzija Insert(RecenzijaInsertRequest insert);
        Model.Recenzija Update(int id, RecenzijaInsertRequest update);
    }
}
