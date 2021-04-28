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
    public class VrstaOsobljaController : ControllerBase
    {
        private readonly IVrstaOsobljaService _service;
        public VrstaOsobljaController(IVrstaOsobljaService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.VrstaOsoblja>> Get(/*[FromQuery]VrstaOsobljaSearchRequest search*/)
        {
            return _service.get(/*search*/);
        }
        [HttpGet("{id}")]
        public ActionResult<Model.VrstaOsoblja> GetByID(int id)
        {
            return _service.getByID(id);
        }
        [HttpPost]
        public Model.VrstaOsoblja Insert(VrstaOsobljaInsertRequest insert)
        {
            return _service.Insert(insert);
        }
        [HttpPut("{id}")]
        public Model.VrstaOsoblja Update(int id, VrstaOsobljaInsertRequest update)
        {
            return _service.Update(id, update);
        }
    }
    //public class VrstaOsobljaController : BaseController<Model.VrstaOsoblja, object>
    //{
    //    public VrstaOsobljaController(IService<VrstaOsoblja, object> service) : base(service)
    //    {
    //    }
    //}
}

