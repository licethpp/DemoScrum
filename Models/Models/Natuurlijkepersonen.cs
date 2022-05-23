using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Natuurlijkepersonen
    {
        public int KlantId { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public int GebruikersAccountId { get; set; }

        public virtual Gebruikersaccount GebruikersAccount { get; set; }
        public virtual Klanten Klant { get; set; }
    }
}
