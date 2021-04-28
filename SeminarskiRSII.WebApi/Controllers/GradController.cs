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
    public class GradController : ControllerBase
    {
        private readonly IGradService _service;
        public GradController(IGradService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Model.Grad>> Get([FromQuery] GradSearchRequest search)
        {
            return _service.get(search);
        }
        [HttpGet("{id}")]
        public ActionResult<Model.Grad> GetByID(int id)
        {
            return _service.GetByID(id);
        }
        [HttpPost]
        public Model.Grad Insert(GradInsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut("{id}")]
        public Model.Grad Update(int id, GradInsertRequest request)
        {
            return _service.Update(id, request);
        }
        [HttpDelete("{id}")]
        public Model.Grad Delete(int id)
        {
            return _service.Delete(id);
        }

    }
}
