using SeminarskiRSII.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Services
{
   public interface IGostiNotifikacijeService
    {
        List<Model.GostiNotifikacije> get(GostiNotifikacijeSearchRequest search);
    }
}
