using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TreatBeauty.Database
{
    public partial class Employee
    {
        [Key, ForeignKey("BaseUser")]
        public int Id { get; set; }
        public BaseUser BaseUser { get; set; }
        public byte[]Photo { get; set; }
        public int SalonId  { get; set; }
        public  Salon Salon { get; set; }
    }
}
