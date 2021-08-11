using System;
using System.Collections.Generic;
using System.Text;

namespace TreatBeauty.Model.Requests
{
    public class SalonInsertRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte[] Photo { get; set; }
        public string Location { get; set; }
        public int CityId { get; set; }
    }
}
