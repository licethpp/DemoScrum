using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Inkomendeleveringen
    {
        public Inkomendeleveringen()
        {
            Inkomendeleveringslijnens = new HashSet<Inkomendeleveringslijnen>();
        }

        public int InkomendeLeveringsId { get; set; }
        public int LeveranciersId { get; set; }
        public string LeveringsbonNummer { get; set; }
        public DateTime Leveringsbondatum { get; set; }
        public DateTime LeverDatum { get; set; }
        public int OntvangerPersoneelslidId { get; set; }

        public virtual Leverancier Leveranciers { get; set; }
        public virtual Personeelsleden OntvangerPersoneelslid { get; set; }
        public virtual ICollection<Inkomendeleveringslijnen> Inkomendeleveringslijnens { get; set; }
    }
}
