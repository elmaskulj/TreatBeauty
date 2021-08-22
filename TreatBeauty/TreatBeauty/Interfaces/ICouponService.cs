
using TreatBeauty.Model;
using TreatBeauty.Model.Requests;

namespace TreatBeauty.Interfaces
{
    public interface ICouponService : ICrudService<Coupon, CouponSearchObject, CouponInsertRequest, CouponInsertRequest>
    {

    }
}
