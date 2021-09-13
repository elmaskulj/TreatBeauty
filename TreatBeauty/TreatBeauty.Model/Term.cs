using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TreatBeauty.Model
{
    public class Term
    {
        [DisplayName("Usluga")]
        public string ServiceName
        {
            get { return Service?.Name; }
        }
        [DisplayName("Početak")]
        public string Start
        {
            get { return $"{StartTime.Value.TimeOfDay.ToString(@"hh\:mm")} h"; }
        }
        [DisplayName("Kraj")]
        public string End
        {
            get { return $"{EndTime.Value.TimeOfDay.ToString(@"hh\:mm") } h"; }
        }
        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
        public string Rezrevisan
        {
            get { return Reserved == true ? "DA" : "NE"; }
        }
        public bool? Reserved { get; set; }
        public DateTime? Date { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int? CustomerId { get; set; }
        //public Customer Customer { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
       
        [DisplayName("Zaposlenik")]
        public string EmplyeeName
        {
            get { return $"{ Employee?.FirstName} {Employee?.LastName}"; }
        }
        
    }
}
