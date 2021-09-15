using System;
using System.Collections.Generic;
using System.Text;

namespace TreatBeauty.Model
{
    public class CustomerCoupon
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CouponId { get; set; }
        public Coupon Coupon { get; set; }
        public bool IsUsed { get; set; }
        public int MyProperty { get; set; }
        public string CouponTitle
        {
            get { return Coupon?.Title; }
        }
        public decimal? CouponValue
        {
            get { return Coupon?.Value; }
        }
    }
}
