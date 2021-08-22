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
    public class NewsService : CrudService<Model.News, Database.News, NewsSearchObject, NewsInsertRequest, NewsInsertRequest>,INewsService
    {
        public NewsService(MyContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IEnumerable<Model.News> Get(NewsSearchObject search)
        {
            var entity = _context.Set<Database.News>().AsQueryable();

            if (search?.SalonId != null)
                entity = entity.Where(x => x.SalonId == search.SalonId);


            if (search?.IncludeList?.Length > 0)
            {
                foreach (var item in search.IncludeList)
                    entity = entity.Include(item);
            }

            var list = entity.ToList();

            return _mapper.Map<List<Model.News>>(list);
        }
    }
}
