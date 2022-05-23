using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Bestellingsstatussen
    {
        public Bestellingsstatussen()
        {
            Bestellingens = new HashSet<Bestellingen>();
        }

        public int BestellingsStatusId { get; set; }
        public string Naam { get; set; }

        public virtual ICollection<Bestellingen> Bestellingens { get; set; }
    }
}
