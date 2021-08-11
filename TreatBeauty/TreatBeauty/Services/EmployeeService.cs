using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Database;
using AutoMapper;
using TreatBeauty.Interfaces;
using TreatBeauty.Model;
using TreatBeauty.Model.Requests;
using Microsoft.EntityFrameworkCore;

namespace TreatBeauty.Services
{
    public class EmployeeService:CrudService<Model.Employee,Database.Employee,EmployeeSearchObject,EmployeeInsertRequest, EmployeeInsertRequest>,IEmployeeService
    {
        public EmployeeService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IEnumerable<Model.Employee> Get(EmployeeSearchObject search = null)
        {
            var entity = _context.Set<Database.Employee>().AsQueryable();

            if (search?.SalonId != 0)
            {
                entity=entity.Where(x => x.SalonId == search.SalonId);
            }

            if (search?.IncludeList?.Length > 0)
            {
                foreach (var item in search.IncludeList)
                    entity = entity.Include(item);
            }

            var list = entity.ToList();

            return _mapper.Map<List<Model.Employee>>(list);
        }
    }
}
