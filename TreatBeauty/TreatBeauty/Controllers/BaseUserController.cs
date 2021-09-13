using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Interfaces;
using TreatBeauty.Model.Requests;

namespace TreatBeauty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BaseUserController : ControllerBase
    {
        private IBaseUserService _service;
        public BaseUserController(IBaseUserService _service)
        {
            this._service = _service;
        }
        [HttpGet("{id}")]
        public Model.BaseUser GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpPost]
        public Model.BaseUser Insert(BaseUserInsertRequest users)
        {
            return _service.Insert(users);
        }
        [HttpGet]
        public IEnumerable<Model.BaseUser> Get()
        {
            return _service.GetAll();
        }
        [HttpPut("{id}")]
        public Model.BaseUser Update(int Id, BaseUserInsertRequest request)
        {
            return _service.Update(Id, request);
        }
    }
}
