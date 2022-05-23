using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Uitgaandeleveringen
    {
        public int UitgaandeLeveringsId { get; set; }
        public int BestelId { get; set; }
        public DateTime VertrekDatum { get; set; }
        public DateTime? AankomstDatum { get; set; }
        public string Trackingcode { get; set; }
        public int KlantId { get; set; }
        public int UitgaandeLeveringsStatusId { get; set; }

        public virtual Bestellingen Bestel { get; set; }
        public virtual Klanten Klant { get; set; }
        public virtual Uitgaandeleveringsstatussen UitgaandeLeveringsStatus { get; set; }
    }
}
