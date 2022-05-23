using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Bestellijnen
    {
        public Bestellijnen()
        {
            Klantenreviews = new HashSet<Klantenreview>();
        }

        public int BestellijnId { get; set; }
        public int BestelId { get; set; }
        public int ArtikelId { get; set; }
        public int AantalBesteld { get; set; }
        public int AantalGeannuleerd { get; set; }

        public virtual Artikelen Artikel { get; set; }
        public virtual Bestellingen Bestel { get; set; }
        public virtual ICollection<Klantenreview> Klantenreviews { get; set; }
    }
}
