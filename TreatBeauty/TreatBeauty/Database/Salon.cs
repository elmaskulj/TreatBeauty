using System;
using System.Collections.Generic;

#nullable disable

namespace TreatBeauty.Database
{
    public partial class Salon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte[] Photo { get; set; }
        public string Location { get; set; }
        public int CityId { get; set; }
        public  City City { get; set; }
        public virtual ICollection<SalonServices> SalonServices { get; set; }

    }
}
