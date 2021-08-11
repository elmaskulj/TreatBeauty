using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Interfaces;
using TreatBeauty.Model.Requests;

namespace TreatBeauty.Controllers
{
    public class SalonController : CrudController<Model.Salon, Model.SalonSearchObject, SalonInsertRequest, SalonInsertRequest>
    {
        public SalonController(ISalonService _service) : base(_service) { }
    }
}
