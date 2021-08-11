using Microsoft.AspNetCore.Mvc;
using TreatBeauty.Interfaces;

namespace TreatBeauty.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : BaseReadController<Model.City, object>
    {
        public CityController(ICityService service) : base(service) { }
    }
}
