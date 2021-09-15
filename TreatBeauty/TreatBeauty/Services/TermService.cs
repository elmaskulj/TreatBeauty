using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Database;
using TreatBeauty.Model.Requests;
using TreatBeauty.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace TreatBeauty.Services
{
    public class TermService: CrudService<Model.Term, Database.Term, Model.TermSearchObject, TermInsertRequest, TermInsertRequest>, ITermService
    {
        public TermService(MyContext context, IMapper mapper) : base(context, mapper) { }

        public override IEnumerable<Model.Term> Get(Model.TermSearchObject search)
        {
            var entity = _context.Set<Database.Term>().AsQueryable();

            if (search?.IncludeList?.Length > 0)
            {
                foreach (var item in search.IncludeList)
                    entity = entity.Include(item);
            }
            if (search.ServiceId.HasValue)
                entity = entity.Where(x => x.ServiceId == search.ServiceId.Value);
            if (search?.SalonId != null && !search.IsReport && search.SalonId != 0)
                entity = entity.Include(x => x.Employee).Where(x => x.Employee.SalonId == search.SalonId);
            if (search.Date.HasValue)
                entity = entity.Where(x => x.Date.Value.Date == search.Date);
            var list = entity.OrderBy(x => x.StartTime).ToList();
            return _mapper.Map<List<Model.Term>>(list);
        }


    }
}
