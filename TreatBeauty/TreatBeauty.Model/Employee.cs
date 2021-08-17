using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TreatBeauty.Model
{
    public class Employee
    {
        [DisplayName("Ime i prezime")]
        public string FirstAndLastName
        {
            get { return $"{BaseUser?.FirstName} {BaseUser?.LastName}"; }
        }
        [DisplayName("Email")]
        public string Email
        {
            get { return BaseUser?.Email; }
        }
        [DisplayName("Telefon")]
        public string PhoneNumber
        {
            get { return BaseUser?.PhoneNumber; }
        }
        public int Id { get; set; }
        public BaseUser BaseUser { get; set; }
        [DisplayName("Slika")]
        public byte[] Photo { get; set; }
        public Salon Salon { get; set; }
        public int SalonId { get; set; }
        [DisplayName("Naziv salona")]
        public string SalonName
        {
            get { return Salon?.Name; }
        }
        [Browsable(false)]
        public string FirstName
        {
            get { return BaseUser?.FirstName; }
        }
        [Browsable(false)]
        public string LastName
        {
            get { return BaseUser?.LastName; }
        }
    }
}
