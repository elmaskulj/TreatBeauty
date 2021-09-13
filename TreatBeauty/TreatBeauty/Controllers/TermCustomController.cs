using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Interfaces;
using TreatBeauty.Model;
using static TreatBeauty.Services.TermCustomService;

namespace TreatBeauty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class TermCustomController :ControllerBase
    {
        private ITermCustomService _service;
        public TermCustomController(ITermCustomService service)
        {
            _service = service;
        }
        [HttpGet]
        public virtual IEnumerable<SalonCustom> Get([FromQuery] TermCustomSearchObject search)
        {
            return _service.GetAll(search);
        }
    }
}
