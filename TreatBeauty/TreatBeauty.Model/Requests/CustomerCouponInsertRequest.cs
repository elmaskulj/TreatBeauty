using System;
using System.Collections.Generic;
using System.Text;

namespace TreatBeauty.Model.Requests
{
    public class CustomerCouponInsertRequest
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int CouponId { get; set; }
        public bool IsUsed { get; set; }
    }
}
