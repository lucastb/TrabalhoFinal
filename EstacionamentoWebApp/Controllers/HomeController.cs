using EstacionamentoWebApp.BLL;
using EstacionamentoWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstacionamentoWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Facade facade = new Facade();
            var num = facade.nDeVagasDisponiveis();
            var valor = num.ToString();
            ViewBag.qntd = valor;
            
            return View();
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}