using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TreatBeauty.Model
{
    public class Salon
    {
        public int Id { get; set; }
        [DisplayName("Naziv salona")]
        public string Name { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        [DisplayName("Datum kreiranja")]
        public DateTime? CreatedAt { get; set; }
        [DisplayName("Slika")]
        public byte[] Photo { get; set; }
        [DisplayName("Lokacija")]
        public string Location { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }

        [DisplayName("Naziv grada")]
        public string CityName
        {
            get { return City?.Name; }
        }
    }
}
