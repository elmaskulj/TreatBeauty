using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Interfaces;
using TreatBeauty.Model;
using TreatBeauty.Model.Requests;

namespace TreatBeauty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]

    public class ServiceController : CrudController<Model.Service,ServiceSearchObject, ServiceInsertRequest, ServiceInsertRequest>
    {
        public ServiceController(IServiceService _service ):base(_service)
        {

        }
        

    }
}
