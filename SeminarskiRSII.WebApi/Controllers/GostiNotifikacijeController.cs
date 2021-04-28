using SeminarskiRSII.Model.Requests;
using SeminarskiRSII.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiRSII.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GostiNotifikacijeController : ControllerBase
    {
        private readonly IGostiNotifikacijeService _service;
        public GostiNotifikacijeController(IGostiNotifikacijeService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.GostiNotifikacije>> Get([FromQuery] GostiNotifikacijeSearchRequest search)
        {
            return _service.get(search);
        }
    }
}
