using System;
using System.Collections.Generic;

#nullable disable

namespace Models.Models
{
    public partial class Eventwachtrijartikelen
    {
        public int ArtikelId { get; set; }
        public int Aantal { get; set; }
        public int MaxAantalInMagazijnPlaats { get; set; }
    }
}
