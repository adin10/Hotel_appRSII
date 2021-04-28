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
    public class SobaOsobljeController : ControllerBase
    {
        private readonly ISobaOsobljeService _service;
        public SobaOsobljeController(ISobaOsobljeService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.SobaOsoblje>> Get()
        {
            return _service.get();
        }
        [HttpGet("{id}")]
        public ActionResult<Model.SobaOsoblje> GetByID(int id)
        {
            return _service.getById(id);
        }
        [HttpPost]
        public Model.SobaOsoblje Insert(SobaOsobljeInsertRequest insert)
        {
            return _service.Insert(insert);
        }
        [HttpPut("{id}")]
        public Model.SobaOsoblje Update(int id, SobaOsobljeInsertRequest update)
        {
            return _service.Update(id, update);
        }
    }

    //public class SobaOsobljeController : BaseController<Model.SobaOsoblje, object>
    //{
    //    public SobaOsobljeController(IService<SobaOsoblje, object> service) : base(service)
    //    {

    //    }
    //}
}

