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
    public class SobaController : ControllerBase
    {
        private readonly ISobaService _service;
        public SobaController(ISobaService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.Soba>> Get([FromQuery] SobaSearchRequest search)
        {
            return _service.get(search);
        }
        [HttpGet("{id}")]
        public ActionResult<Model.Soba> GetByID(int id)
        {
            return _service.getByID(id);
        }
        [HttpPost]
        public Model.Soba Insert(SobaInsertRequest insert)
        {
            return _service.Insert(insert);
        }
        [HttpPut("{id}")]
        public Model.Soba Update(int id, SobaInsertRequest update)
        {
            return _service.Update(id, update);
        }
        [HttpDelete("{id}")]
        public Model.Soba Delete(int id)
        {
            return _service.Delete(id);
        }
    }
    //public class SobaController : BaseCRUDController<Model.Soba, SobaSearchRequest, SobaInsertRequest, SobaInsertRequest>
    //{
    //    public SobaController(ICRUDService<Soba, SobaSearchRequest, SobaInsertRequest, SobaInsertRequest> service) : base(service)
    //    {
    //    }
    //}
}

