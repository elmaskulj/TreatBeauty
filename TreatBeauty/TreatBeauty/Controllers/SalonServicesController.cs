using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Interfaces;

namespace TreatBeauty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalonServicesController : CrudController<Model.SalonServices, Model.SalonServicesSearchObject, Model.SalonServices,object>
    {
        public SalonServicesController(ISalonServicesService service) : base(service)
        {
        }
    }
}


