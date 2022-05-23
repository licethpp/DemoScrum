using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Rechtspersonen
    {
        public Rechtspersonen()
        {
            Contactpersonens = new HashSet<Contactpersonen>();
        }

        public int KlantId { get; set; }
        public string Naam { get; set; }
        public string BtwNummer { get; set; }

        public virtual Klanten Klant { get; set; }
        public virtual ICollection<Contactpersonen> Contactpersonens { get; set; }
    }
}
