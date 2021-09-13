using System;
using System.Collections.Generic;
using System.Text;


namespace TreatBeauty.Model
{
    public class TermCustom
    {
        //[Key]
        public int Id { get; set; }
        public int SalonId { get; set; }
        public string SalonName { get; set; }
        public byte[] SalonPhoto { get; set; }
        public string CityName { get; set; }
        public string Location { get; set; }
        public string ServiceName { get; set; }
        public decimal ServicePrice { get; set; }
        public int ServiceId { get; set; }
        public DateTime TermDate { get; set; }


    }
}
