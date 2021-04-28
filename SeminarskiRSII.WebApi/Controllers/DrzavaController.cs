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
    public class DrzavaController : ControllerBase
    {
        private readonly IDrzavaService _service;
        public DrzavaController(IDrzavaService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.Drzava>> Get([FromQuery] DrzavaSearchRequest search)
        {
            return _service.get(search);
        }
        [HttpGet("{id}")]
        public ActionResult<Model.Drzava> GetByID(int id)
        {
            return _service.GetByID(id);
        }
        [HttpPost]
        public Model.Drzava Insert(DrzavaSearchRequest insert)
        {
            return _service.Insert(insert);
        }
        [HttpPut("{id}")]
        public Model.Drzava Update(int id, DrzavaSearchRequest update)
        {
            return _service.Update(id, update);
        }
    }
}
