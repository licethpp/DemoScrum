using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Securitygroepen
    {
        public Securitygroepen()
        {
            Personeelslidsecuritygroepens = new HashSet<Personeelslidsecuritygroepen>();
        }

        public int SecurityGroepId { get; set; }
        public string Naam { get; set; }

        public virtual ICollection<Personeelslidsecuritygroepen> Personeelslidsecuritygroepens { get; set; }
    }
}
