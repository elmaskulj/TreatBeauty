using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreatBeauty.Database
{
    public class SalonServices
    {
        public int SalonServicesId { get; set; }
        public int SalonId { get; set; }
        public Salon Salon {get;set;}
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
