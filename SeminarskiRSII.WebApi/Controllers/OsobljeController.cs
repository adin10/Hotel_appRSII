﻿using SeminarskiRSII.Model.Requests;
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
    public class OsobljeController : ControllerBase
    {
        private readonly IOsobljeService _service;
        public OsobljeController(IOsobljeService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.Osoblje>> Get([FromQuery] OsobljeSearchRequest search)
        {
            return _service.get(search);
        }
        [HttpGet("{id}")]
        public ActionResult<Model.Osoblje> GetByID(int id)
        {
            return _service.getByID(id);
        }
        [HttpPost]
        public Model.Osoblje Insert(OsobljeInsertRequest insert)
        {
            return _service.Insert(insert);
        }
        [HttpPut("{id}")]
        public Model.Osoblje Update(int id, OsobljeInsertRequest update)
        {
            return _service.Update(id, update);
        }
    }
}
