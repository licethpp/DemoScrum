using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Artikelcategorieen
    {
        public int CategorieId { get; set; }
        public int ArtikelId { get; set; }

        public virtual Artikelen Artikel { get; set; }
        public virtual Categorieen Categorie { get; set; }
    }
}
