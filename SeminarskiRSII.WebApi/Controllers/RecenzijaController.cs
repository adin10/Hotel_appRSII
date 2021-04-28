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
    public class RecenzijaController : ControllerBase
    {
        private readonly IRecenzijaService _service;
        public RecenzijaController(IRecenzijaService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.Recenzija>> Get([FromQuery] RecenzijaSearchRequest search)
        {
            return _service.get(search);
        }
        [HttpGet("{id}")]
        public ActionResult<Model.Recenzija> GetByID(int id)
        {
            return _service.getByID(id);
        }
        [HttpPost]
        public Model.Recenzija Insert(RecenzijaInsertRequest insert)
        {
            return _service.Insert(insert);
        }
        [HttpPut("{id}")]
        public Model.Recenzija Update(int id, RecenzijaInsertRequest update)
        {
            return _service.Update(id, update);
        }
    }
}
