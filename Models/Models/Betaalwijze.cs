using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Betaalwijze
    {
        public Betaalwijze()
        {
            Bestellingens = new HashSet<Bestellingen>();
        }

        public int BetaalwijzeId { get; set; }
        public string Naam { get; set; }

        public virtual ICollection<Bestellingen> Bestellingens { get; set; }
    }
}
