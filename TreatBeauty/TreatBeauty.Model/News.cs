using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TreatBeauty.Model
{
   public class News
    {
        public int Id { get; set; }
        [DisplayName("Naslov")]
        public string Title { get; set; }
        public string Description { get; set; }
        [DisplayName("Datum kreiranja")]

        public DateTime? CreatedAt { get; set; }
        [DisplayName("Slika")]

        public byte[] Photo { get; set; }
        public int SalonId { get; set; }
        public Salon Salon { get; set; }
        [DisplayName("Aktivna")]

        public bool Active { get; set; }
    }
}
