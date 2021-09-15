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
    public class CustomerCouponsService : CrudService<Model.CustomerCoupon, Database.CustomerCoupon, CustomerCouponSearchObject, CustomerCouponInsertRequest, CustomerCouponInsertRequest>, ICustomerCouponsService
    {
        public CustomerCouponsService(MyContext context, IMapper mapper) : base(context, mapper)
        {

        }
        public override IEnumerable<Model.CustomerCoupon> Get(CustomerCouponSearchObject search = null)
        {
            var entity = _context.Set<Database.CustomerCoupon>().AsQueryable();

            if (search?.CouponId!=null)
                entity = entity.Where(x => x.CouponId == search.CouponId);

            if (search?.CustomerId != null)
                entity = entity.Where(x => x.CustomerId == search.CustomerId);

            entity = entity.Include("Coupon");
            var list = entity.ToList();

            return _mapper.Map<List<Model.CustomerCoupon>>(list);
        }

    }
}
