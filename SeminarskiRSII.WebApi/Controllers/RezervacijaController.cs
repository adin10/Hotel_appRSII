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
    public class RezervacijaController : ControllerBase
    {
        private readonly IRezervacijaService _service;

        public RezervacijaController(IRezervacijaService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.Rezervacija>> Get([FromQuery] RezervacijaSearchRequest search)
        {
            return _service.get(search);
        }
        [HttpGet("{id}")]
        public ActionResult<Model.Rezervacija> GetByID(int id)
        {
            return _service.getByID(id);
        }
        [HttpPost]
        public Model.Rezervacija Insert(RezervacijaInsertRequest insert)
        {
            return _service.Insert(insert);
        }
        [HttpPut("{id}")]
        public Model.Rezervacija Update(int id, RezervacijaInsertRequest update)
        {
            return _service.Update(id, update);
        }
        [HttpDelete("{id}")]
        public Model.Rezervacija Delete(int id)
        {
            return _service.Delete(id);
        }
    }
}
