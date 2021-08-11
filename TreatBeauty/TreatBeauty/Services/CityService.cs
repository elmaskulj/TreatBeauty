using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Database;
using TreatBeauty.Interfaces;

namespace TreatBeauty.Services
{
    public class CityService : ReadService<Model.City, Database.City, object>, ICityService
    {
        public CityService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
