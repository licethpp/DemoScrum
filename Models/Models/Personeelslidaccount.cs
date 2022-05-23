using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Personeelslidaccount
    {
        public Personeelslidaccount()
        {
            Chatgespreklijnens = new HashSet<Chatgespreklijnen>();
            Personeelsledens = new HashSet<Personeelsleden>();
        }

        public int PersoneelslidAccountId { get; set; }
        public string Emailadres { get; set; }
        public string Paswoord { get; set; }
        public bool Disabled { get; set; }

        public virtual ICollection<Chatgespreklijnen> Chatgespreklijnens { get; set; }
        public virtual ICollection<Personeelsleden> Personeelsledens { get; set; }
    }
}
