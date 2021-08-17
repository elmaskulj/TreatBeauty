using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Database;
using TreatBeauty.Interfaces;

namespace TreatBeauty.Services
{
    public class SalonServicesService : CrudService<Model.SalonServices, Database.SalonServices, Model.SalonServicesSearchObject, Model.SalonServices,object>, ISalonServicesService
    {
        public SalonServicesService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IEnumerable<Model.SalonServices> Get(Model.SalonServicesSearchObject search)
        {
            var entity = _context.Set<Database.SalonServices>().AsQueryable();

            if (search?.SalonId != null)
                entity = entity.Where(x => x.SalonId==search.SalonId);


            if (search?.IncludeList?.Length > 0)
            {
                foreach (var item in search.IncludeList)
                    entity = entity.Include(item);
            }
            var list = entity.ToList();

            return _mapper.Map<IEnumerable<Model.SalonServices>>(list);
        }
    }
}
