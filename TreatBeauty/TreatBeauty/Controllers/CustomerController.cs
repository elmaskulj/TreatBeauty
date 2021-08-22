using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Interfaces;
using TreatBeauty.Model;

namespace TreatBeauty.Controllers
{
    public class CustomerController : CrudController<Model.Customer, CustomerSearchObject, object, object>
    {
        public CustomerController(ICustomerService _service) : base(_service)
        {

        }
    }
}
