using System;
using System.Collections.Generic;
using System.Text;

namespace TreatBeauty.Model
{
    public class SalonServices
    {
        public int SalonServicesId { get; set; }
        public int SalonId { get; set; }
        public Salon Salon { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
