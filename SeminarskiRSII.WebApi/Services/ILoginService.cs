using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
   public interface ILoginService
    {
        Model.Osoblje Authenticiraj(string username, string pass);
        Model.Osoblje AuthenticirajGosta(string username, string pass);
    }
}
