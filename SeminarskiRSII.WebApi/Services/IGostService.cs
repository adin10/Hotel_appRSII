using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
   public interface IGostService
    {
        List<Model.Gost> get(GostiSearchRequest search);
        Model.Gost getById(int id);
        Model.Gost Insert(GostiInsertRequest requst);
        Model.Gost Update(int id, GostiInsertRequest requst);
        Model.Gost AuthenticirajGosta(string username, string pass);

    }
}
