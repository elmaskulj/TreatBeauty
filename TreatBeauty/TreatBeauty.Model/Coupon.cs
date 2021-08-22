using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TreatBeauty.Model
{
   public class Coupon
    {
        public int Id { get; set; }
        [DisplayName("Naziv")]
        public string Title { get; set; }
        [DisplayName("Datum početka")]

        public DateTime StartDate { get; set; }
        [DisplayName("Datum isteka")]

        public DateTime EndDate { get; set; }
        [DisplayName("Aktivan")]

        public bool IsActive { get; set; }
        [DisplayName("Iznos")]

        public decimal Value { get; set; }

    }
}
