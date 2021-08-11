using System;
using System.Collections.Generic;
using System.Text;

namespace TreatBeauty.Model.Requests
{
    public class ServiceInsertRequest
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? Duration { get; set; }
        public byte[] Photo { get; set; }
        public int CategoryId { get; set; }
    }
}
