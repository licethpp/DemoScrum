using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Plaatsen
    {
        public Plaatsen()
        {
            Adressens = new HashSet<Adressen>();
            Leveranciers = new HashSet<Leverancier>();
        }

        public int PlaatsId { get; set; }
        public string Postcode { get; set; }
        public string Plaats { get; set; }

        public virtual ICollection<Adressen> Adressens { get; set; }
        public virtual ICollection<Leverancier> Leveranciers { get; set; }
    }
}
