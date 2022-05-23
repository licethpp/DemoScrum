using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Klantenreview
    {
        public int KlantenReviewId { get; set; }
        public string Nickname { get; set; }
        public int Score { get; set; }
        public string Commentaar { get; set; }
        public DateTime Datum { get; set; }
        public int BestellijnId { get; set; }

        public virtual Bestellijnen Bestellijn { get; set; }
    }
}
