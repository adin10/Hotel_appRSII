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
    public class GostController : ControllerBase
    {
        private readonly IGostService _service;
        public GostController(IGostService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Model.Gost>> Get([FromQuery] GostiSearchRequest search)
        {
            return _service.get(search);
        }
        [HttpGet("{id}")]
        public ActionResult<Model.Gost> GetByID(int id)
        {
            return _service.getById(id);
        }
        [HttpPost]
        public Model.Gost Insert(GostiInsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut("{id}")]
        public Model.Gost Update(int id, GostiInsertRequest request)
        {
            return _service.Update(id, request);
        }
    }
}
