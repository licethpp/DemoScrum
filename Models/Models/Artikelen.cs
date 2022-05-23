using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Artikelen
    {
        public Artikelen()
        {
            Artikelcategorieens = new HashSet<Artikelcategorieen>();
            Artikelleveranciersinfolijnens = new HashSet<Artikelleveranciersinfolijnen>();
            Bestellijnens = new HashSet<Bestellijnen>();
            Inkomendeleveringslijnens = new HashSet<Inkomendeleveringslijnen>();
            Magazijnplaatsens = new HashSet<Magazijnplaatsen>();
            Veelgesteldevragenartikels = new HashSet<Veelgesteldevragenartikel>();
            Wishlistitems = new HashSet<Wishlistitem>();
        }

        public int ArtikelId { get; set; }
        public string Ean { get; set; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public decimal Prijs { get; set; }
        public int GewichtInGram { get; set; }
        public int Bestelpeil { get; set; }
        public int Voorraad { get; set; }
        public int MinimumVoorraad { get; set; }
        public int MaximumVoorraad { get; set; }
        public int Levertijd { get; set; }
        public int AantalBesteldLeverancier { get; set; }
        public int MaxAantalInMagazijnPlaats { get; set; }

        public virtual ICollection<Artikelcategorieen> Artikelcategorieens { get; set; }
        public virtual ICollection<Artikelleveranciersinfolijnen> Artikelleveranciersinfolijnens { get; set; }
        public virtual ICollection<Bestellijnen> Bestellijnens { get; set; }
        public virtual ICollection<Inkomendeleveringslijnen> Inkomendeleveringslijnens { get; set; }
        public virtual ICollection<Magazijnplaatsen> Magazijnplaatsens { get; set; }
        public virtual ICollection<Veelgesteldevragenartikel> Veelgesteldevragenartikels { get; set; }
        public virtual ICollection<Wishlistitem> Wishlistitems { get; set; }
    }
}
