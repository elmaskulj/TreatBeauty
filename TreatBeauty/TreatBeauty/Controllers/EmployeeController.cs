using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Model;
using TreatBeauty.Model.Requests;
using Microsoft.AspNetCore.Authorization;
using TreatBeauty.Interfaces;
using TreatBeauty.Model;


namespace TreatBeauty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class EmployeeController : CrudController<Model.Employee,EmployeeSearchObject,EmployeeInsertRequest, EmployeeInsertRequest>
    {
        public EmployeeController(IEmployeeService _service) : base(_service) { }
    }
    
}
