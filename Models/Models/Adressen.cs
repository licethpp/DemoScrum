using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Adressen
    {
        public Adressen()
        {
            BestellingenFacturatieAdres = new HashSet<Bestellingen>();
            BestellingenLeveringsAdres = new HashSet<Bestellingen>();
            KlantenFacturatieAdres = new HashSet<Klanten>();
            KlantenLeveringsAdres = new HashSet<Klanten>();
        }

        public int AdresId { get; set; }
        public string Straat { get; set; }
        public string HuisNummer { get; set; }
        public string Bus { get; set; }
        public int PlaatsId { get; set; }
        public bool? Actief { get; set; }

        public virtual Plaatsen Plaats { get; set; }
        public virtual ICollection<Bestellingen> BestellingenFacturatieAdres { get; set; }
        public virtual ICollection<Bestellingen> BestellingenLeveringsAdres { get; set; }
        public virtual ICollection<Klanten> KlantenFacturatieAdres { get; set; }
        public virtual ICollection<Klanten> KlantenLeveringsAdres { get; set; }
    }
}
