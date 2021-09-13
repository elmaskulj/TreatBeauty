using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TreatBeauty.Model
{
    public class Customer
    {
        public int Id { get; set; }
        [DisplayName("Ime i prezime")]
        public string FirstAndLastName
        {
            get { return $"{BaseUser?.FirstName} {BaseUser?.LastName}"; }
        }
        public BaseUser BaseUser { get; set; }
        public string PhoneNumber { get; set; }
        
    }
}
