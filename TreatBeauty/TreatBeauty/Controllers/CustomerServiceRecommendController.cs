using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class CustomerServiceRecommendController : ControllerBase
    {
        private readonly ICustomerServiceRecommendService service;
        public CustomerServiceRecommendController(ICustomerServiceRecommendService service)
        {
            this.service = service;
        }
        [HttpGet("{CustomerId}")]
        public List<Model.CustomerServiceRecommend> Get(int CustomerId) {
            return service.Get(CustomerId);
        }

    }
}
