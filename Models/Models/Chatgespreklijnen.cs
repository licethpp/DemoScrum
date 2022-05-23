using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Chatgespreklijnen
    {
        public int ChatgesprekLijnId { get; set; }
        public int ChatgesprekId { get; set; }
        public string Bericht { get; set; }
        public int? GebruikersAccountId { get; set; }
        public int? PersoneelslidAccountId { get; set; }

        public virtual Chatgesprekken Chatgesprek { get; set; }
        public virtual Gebruikersaccount GebruikersAccount { get; set; }
        public virtual Personeelslidaccount PersoneelslidAccount { get; set; }
    }
}
