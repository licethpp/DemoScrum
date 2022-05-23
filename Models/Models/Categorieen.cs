using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Categorieen
    {
        public Categorieen()
        {
            Artikelcategorieens = new HashSet<Artikelcategorieen>();
            InverseHoofdCategorie = new HashSet<Categorieen>();
        }

        public int CategorieId { get; set; }
        public string Naam { get; set; }
        public int? HoofdCategorieId { get; set; }

        public virtual Categorieen HoofdCategorie { get; set; }
        public virtual ICollection<Artikelcategorieen> Artikelcategorieens { get; set; }
        public virtual ICollection<Categorieen> InverseHoofdCategorie { get; set; }
    }
}
