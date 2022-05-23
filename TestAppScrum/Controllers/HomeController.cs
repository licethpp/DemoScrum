using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestAppScrum.Models;

namespace TestAppScrum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            prulariacomContext p = new prulariacomContext(); //moet normaal van service komen maar is voor de demo
            CategorieViewModel c = new CategorieViewModel();
            c.Categorieen = GetSelectListItemsCategorieen(p.Categorieens.ToList());
            return View(c);
        }

        private List<SelectListItem> GetSelectListItemsCategorieen(IEnumerable<Categorieen> elements)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.CategorieId.ToString(),
                    Text = element.Naam
                });
            }
            return selectList;
        }

        public ActionResult FillCategorie(int categorieid)
        {
            prulariacomContext p = new prulariacomContext(); // moet normaal van de service komen maar is voor de demo

            var cat = p.Categorieens.Where(x => x.CategorieId == categorieid).FirstOrDefault();
            return Json(cat);
        }

        //Aanpassen
        [HttpPost]
        public IActionResult Aanpassen(CategorieViewModel p)
        {
            var s = 0; //hier een update naar de database
            return null;
        }

            public IActionResult Categorie()
        {
            return View();
        } 
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
