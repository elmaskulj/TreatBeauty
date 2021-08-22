using System;
using System.Collections.Generic;
using System.Text;

namespace TreatBeauty.Model.Requests
{
    public class CouponInsertRequest
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public decimal Value { get; set; }

    }
}
