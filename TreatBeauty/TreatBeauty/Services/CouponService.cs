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

    }
}
