using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StockCafeteria.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Main()
        {
            ViewBag.Title = "Accueil";

            return View();
        }
        public ActionResult AjoutCommande()
        {
            ViewBag.Title = "Ajouter une commande";

            return View();
        }
    }
}
