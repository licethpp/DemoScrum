using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Wishlistitem
    {
        public int WishListItemId { get; set; }
        public int ArtikelId { get; set; }
        public int GebruikersAccountId { get; set; }
        public DateTime AanvraagDatum { get; set; }
        public int Aantal { get; set; }
        public DateTime? EmailGestuurdDatum { get; set; }

        public virtual Artikelen Artikel { get; set; }
        public virtual Gebruikersaccount GebruikersAccount { get; set; }
    }
}
