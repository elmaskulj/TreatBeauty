using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Database;
using TreatBeauty.Interfaces;
using TreatBeauty.Model;
using TreatBeauty.Model.Requests;

namespace TreatBeauty.Services
{
    public class CouponService : CrudService<Model.Coupon, Database.Coupon, CouponSearchObject, CouponInsertRequest, CouponInsertRequest>, ICouponService
    {
        public CouponService(MyContext context, IMapper mapper) : base(context, mapper) { }
        public override IEnumerable<Model.Coupon> Get(CouponSearchObject search = null)
        {
            var entity = _context.Set<Database.Coupon>().AsQueryable();
            entity = entity.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now);

            var customerCouponEntity = _context.Set<Database.CustomerCoupon>().AsQueryable();

            if (search?.CustomerId != null)
                customerCouponEntity = customerCouponEntity.Where(x => x.CustomerId == search.CustomerId);

            var list = entity.ToList();
            var customerCouponList = customerCouponEntity.ToList();

            var mergeList = list.Where(x => !customerCouponList.Any(y => y.CouponId == x.Id)).ToList();

            return _mapper.Map<List<Model.Coupon>>(mergeList);
        }

    }
}
