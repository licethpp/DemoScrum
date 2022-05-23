using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Personeelslidsecuritygroepen
    {
        public int PersoneelslidId { get; set; }
        public int SecurityGroepId { get; set; }

        public virtual Personeelsleden Personeelslid { get; set; }
        public virtual Securitygroepen SecurityGroep { get; set; }
    }
}
