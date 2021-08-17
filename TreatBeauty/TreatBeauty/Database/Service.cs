using System;
using System.Collections.Generic;

#nullable disable

namespace TreatBeauty.Database
{
    public partial class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? Duration { get; set; }
        public byte[] Photo { get; set; }
        public  int CategoryId { get; set; }
        public  Category Category { get; set; }
        public virtual ICollection<SalonServices> SalonServices { get; set; }

    }
}
