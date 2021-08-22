using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreatBeauty.Interfaces;
using TreatBeauty.Model.Requests;

namespace TreatBeauty.Controllers
{
    public class CouponController : CrudController<Model.Coupon, Model.CouponSearchObject, CouponInsertRequest, CouponInsertRequest>
    {
        public CouponController(ICouponService _service) : base(_service)
        {

        }

    }
}
