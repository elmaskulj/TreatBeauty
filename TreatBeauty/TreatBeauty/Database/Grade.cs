using System;
using System.Collections.Generic;

#nullable disable

namespace TreatBeauty.Database
{
    public partial class Grade
    {
        public int? Grade1 { get; set; }
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int CustomerId { get; set; }
        public  Customer Customer { get; set; }
        public int TermId { get; set; }
        public  Term Term { get; set; }
    }
}
