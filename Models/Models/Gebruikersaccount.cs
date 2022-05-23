using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Gebruikersaccount
    {
        public Gebruikersaccount()
        {
            Chatgesprekkens = new HashSet<Chatgesprekken>();
            Chatgespreklijnens = new HashSet<Chatgespreklijnen>();
            Contactpersonens = new HashSet<Contactpersonen>();
            Natuurlijkepersonens = new HashSet<Natuurlijkepersonen>();
            Wishlistitems = new HashSet<Wishlistitem>();
        }

        public int GebruikersAccountId { get; set; }
        public string Emailadres { get; set; }
        public string Paswoord { get; set; }
        public bool Disabled { get; set; }

        public virtual ICollection<Chatgesprekken> Chatgesprekkens { get; set; }
        public virtual ICollection<Chatgespreklijnen> Chatgespreklijnens { get; set; }
        public virtual ICollection<Contactpersonen> Contactpersonens { get; set; }
        public virtual ICollection<Natuurlijkepersonen> Natuurlijkepersonens { get; set; }
        public virtual ICollection<Wishlistitem> Wishlistitems { get; set; }
    }
}
