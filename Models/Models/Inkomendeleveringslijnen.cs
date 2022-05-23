using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Inkomendeleveringslijnen
    {
        public int InkomendeLeveringsId { get; set; }
        public int ArtikelId { get; set; }
        public int AantalGoedgekeurd { get; set; }
        public int AantalTeruggestuurd { get; set; }
        public int MagazijnPlaatsId { get; set; }

        public virtual Artikelen Artikel { get; set; }
        public virtual Inkomendeleveringen InkomendeLeverings { get; set; }
        public virtual Magazijnplaatsen MagazijnPlaats { get; set; }
    }
}
