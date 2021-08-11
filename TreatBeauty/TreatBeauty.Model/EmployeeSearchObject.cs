using System;
using System.Collections.Generic;
using System.Text;

namespace TreatBeauty.Model
{
   public class EmployeeSearchObject
    {
        public int SalonId { get; set; }
        public string[] IncludeList { get; set; }
    }
}
