using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Contactpersonen
    {
        public int ContactpersoonId { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public string Functie { get; set; }
        public int KlantId { get; set; }
        public int GebruikersAccountId { get; set; }

        public virtual Gebruikersaccount GebruikersAccount { get; set; }
        public virtual Rechtspersonen Klant { get; set; }
    }
}
