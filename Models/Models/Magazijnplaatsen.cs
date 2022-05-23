using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Magazijnplaatsen
    {
        public Magazijnplaatsen()
        {
            Inkomendeleveringslijnens = new HashSet<Inkomendeleveringslijnen>();
        }

        public int MagazijnPlaatsId { get; set; }
        public int? ArtikelId { get; set; }
        public string Rij { get; set; }
        public int Rek { get; set; }
        public int Aantal { get; set; }

        public virtual Artikelen Artikel { get; set; }
        public virtual ICollection<Inkomendeleveringslijnen> Inkomendeleveringslijnens { get; set; }
    }
}
