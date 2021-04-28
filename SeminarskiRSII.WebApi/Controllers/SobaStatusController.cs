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
    public class SobaStatusController : ControllerBase
    {
        private readonly ISobaStatusService _service;
        public SobaStatusController(ISobaStatusService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.SobaStatus>> Get()
        {
            return _service.get();
        }
        [HttpGet("{id}")]
        public ActionResult<Model.SobaStatus> GetByID(int id)
        {
            return _service.getByID(id);
        }
        [HttpPost]
        public Model.SobaStatus Insert(SobaStatusInsertRequest insert)
        {
            return _service.Insert(insert);
        }
        [HttpPut("{id}")]
        public Model.SobaStatus Update(int id, SobaStatusInsertRequest update)
        {
            return _service.Update(id, update);
        }
    }
    //public class SobaStatusController : BaseController<Model.SobaStatus, object>
    //{
    //    public SobaStatusController(IService<SobaStatus, object> service) : base(service)
    //    {

    //    }
    //}
}

