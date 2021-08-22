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
    public class NewsController : CrudController<Model.News, NewsSearchObject, NewsInsertRequest, NewsInsertRequest>
    {
        public NewsController(INewsService _service) : base(_service)
        {

        }

    }
}
