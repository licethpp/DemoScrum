using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Klanten
    {
        public Klanten()
        {
            Bestellingens = new HashSet<Bestellingen>();
            Uitgaandeleveringens = new HashSet<Uitgaandeleveringen>();
        }

        public int KlantId { get; set; }
        public int FacturatieAdresId { get; set; }
        public int LeveringsAdresId { get; set; }

        public virtual Adressen FacturatieAdres { get; set; }
        public virtual Adressen LeveringsAdres { get; set; }
        public virtual Natuurlijkepersonen Natuurlijkepersonen { get; set; }
        public virtual Rechtspersonen Rechtspersonen { get; set; }
        public virtual ICollection<Bestellingen> Bestellingens { get; set; }
        public virtual ICollection<Uitgaandeleveringen> Uitgaandeleveringens { get; set; }
    }
}
