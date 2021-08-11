using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Database;
using TreatBeauty.Interfaces;
using TreatBeauty.Model.Requests;

namespace TreatBeauty.Services
{
    public class ServiceService : CrudService<Model.Service, Database.Service, Model.ServiceSearchObject, ServiceInsertRequest, ServiceInsertRequest>, IServiceService
    {
        public ServiceService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IEnumerable<Model.Service> Get(Model.ServiceSearchObject search)
        {
            var entity = _context.Set<Database.Service>().AsQueryable();

            if (search?.CategoryId != null)
                entity = entity.Where(x => x.CategoryId == search.CategoryId);


            if (search?.IncludeList?.Length > 0)
            {
                foreach (var item in search.IncludeList)
                    entity = entity.Include(item);
            }

            var list = entity.ToList();

            return _mapper.Map<List<Model.Service>>(list);
        }
    }
}
