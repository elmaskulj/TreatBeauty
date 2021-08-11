using System;
using System.Collections.Generic;

#nullable disable

namespace TreatBeauty.Database
{
    public partial class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte[] Photo { get; set; }
        public int SalonId { get; set; }
        public  Salon Salon { get; set; }
    }
}
