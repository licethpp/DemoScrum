using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Personeelsleden
    {
        public Personeelsleden()
        {
            Inkomendeleveringens = new HashSet<Inkomendeleveringen>();
            Personeelslidsecuritygroepens = new HashSet<Personeelslidsecuritygroepen>();
        }

        public int PersoneelslidId { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public bool? InDienst { get; set; }
        public int PersoneelslidAccountId { get; set; }

        public virtual Personeelslidaccount PersoneelslidAccount { get; set; }
        public virtual ICollection<Inkomendeleveringen> Inkomendeleveringens { get; set; }
        public virtual ICollection<Personeelslidsecuritygroepen> Personeelslidsecuritygroepens { get; set; }
    }
}
