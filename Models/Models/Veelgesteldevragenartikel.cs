using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Veelgesteldevragenartikel
    {
        public int VeelgesteldeVragenArtikelId { get; set; }
        public int ArtikelId { get; set; }
        public string Vraag { get; set; }
        public string Antwoord { get; set; }

        public virtual Artikelen Artikel { get; set; }
    }
}
