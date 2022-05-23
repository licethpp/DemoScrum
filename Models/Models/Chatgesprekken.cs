using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Chatgesprekken
    {
        public Chatgesprekken()
        {
            Chatgespreklijnens = new HashSet<Chatgespreklijnen>();
        }

        public int ChatgesprekId { get; set; }
        public int GebruikersAccountId { get; set; }

        public virtual Gebruikersaccount GebruikersAccount { get; set; }
        public virtual ICollection<Chatgespreklijnen> Chatgespreklijnens { get; set; }
    }
}
