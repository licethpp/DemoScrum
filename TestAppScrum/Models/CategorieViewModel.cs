using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppScrum.Models
{
    public class CategorieViewModel
    {
        public string Naam { get; set; }
        public int CategoryId { get; set; }

        public List<SelectListItem> Categorieen { get; set; }
    }
}
