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
    public class CjenovnikController : ControllerBase
    {
        private readonly ICjenovnikService _service;
        public CjenovnikController(ICjenovnikService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.Cjenovnik>> Get()
        {
            return _service.get();
        }
        [HttpGet("{id}")]
        public ActionResult<Model.Cjenovnik> GetByID(int id)
        {
            return _service.getById(id);
        }
        [HttpPost]
        public Model.Cjenovnik Insert(CijenaInsertRequest insert)
        {
            return _service.Insert(insert);
        }
        [HttpPut("{id}")]
        public Model.Cjenovnik Update(int id, CijenaInsertRequest update)
        {
            return _service.Update(id, update);
        }
    }
}
