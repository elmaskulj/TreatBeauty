using System;
using System.Collections.Generic;

#nullable disable

namespace TreatBeauty.Database
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Photo { get; set; }
    }
}
