using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Bestellingen
    {
        public Bestellingen()
        {
            Bestellijnens = new HashSet<Bestellijnen>();
            Uitgaandeleveringens = new HashSet<Uitgaandeleveringen>();
        }

        public int BestelId { get; set; }
        public int KlantId { get; set; }
        public bool Betaald { get; set; }
        public string Betalingscode { get; set; }
        public int BetaalwijzeId { get; set; }
        public bool Annulatie { get; set; }
        public DateTime? Annulatiedatum { get; set; }
        public string Terugbetalingscode { get; set; }
        public int BestellingsStatusId { get; set; }
        public bool ActiecodeGebruikt { get; set; }
        public string Bedrijfsnaam { get; set; }
        public string BtwNummer { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public int FacturatieAdresId { get; set; }
        public int LeveringsAdresId { get; set; }

        public virtual Bestellingsstatussen BestellingsStatus { get; set; }
        public virtual Betaalwijze Betaalwijze { get; set; }
        public virtual Adressen FacturatieAdres { get; set; }
        public virtual Klanten Klant { get; set; }
        public virtual Adressen LeveringsAdres { get; set; }
        public virtual ICollection<Bestellijnen> Bestellijnens { get; set; }
        public virtual ICollection<Uitgaandeleveringen> Uitgaandeleveringens { get; set; }
    }
}
