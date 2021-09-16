using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Database;
using TreatBeauty.Interfaces;
using TreatBeauty.Model;

namespace TreatBeauty.Services
{
    public class CustomerServiceRecommendService : ICustomerServiceRecommendService
    {
        protected readonly MyContext _context;
        protected readonly IMapper _mapper;

        public CustomerServiceRecommendService( MyContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        List<Model.CustomerServiceRecommend> ICustomerServiceRecommendService.Get(int CustomerId)
        {
            var entity = _context.Set<Database.CustomerServiceRecommend>().AsQueryable();

            entity = entity.Where(x => x.CustomerId == CustomerId);

            List<Model.CustomerServiceRecommend> list = entity.Include(x=>x.Service)
            .Select(x => new Model.CustomerServiceRecommend
            {
                Id=x.Id,
                CustomerId=x.CustomerId,
                ServiceId=x.ServiceId,
                ServiceName=x.Service.Name,
                ServicPrice=x.Service.Price.Value,

            }).OrderByDescending(x=>x.Id).Take(5).ToList();
            return list;
        }
    }
}
