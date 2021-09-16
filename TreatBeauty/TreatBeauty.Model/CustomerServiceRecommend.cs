using System;
using System.Collections.Generic;
using System.Text;

namespace TreatBeauty.Model
{
    public class CustomerServiceRecommend
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int CustomerId { get; set; }
        public string ServiceName{ get; set; }
        public decimal ServicPrice { get; set; }
    }
}
