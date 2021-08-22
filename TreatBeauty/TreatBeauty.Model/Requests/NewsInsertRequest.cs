using System;
using System.Collections.Generic;
using System.Text;

namespace TreatBeauty.Model.Requests
{
    public class NewsInsertRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public byte[] Photo { get; set; }
        public int SalonId { get; set; }
       // public Salon Salon { get; set; }
        public bool Active { get; set; }
    }
}
