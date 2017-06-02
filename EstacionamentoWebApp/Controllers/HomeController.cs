
using EstacionamentoWebApp.BLL;
using EstacionamentoWebApp.Models;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zen.Barcode;

namespace EstacionamentoWebApp.Controllers
{
    public class HomeController : Controller
    {
        Code128BarcodeDraw bdf = BarcodeDrawFactory.Code128WithChecksum;
        Facade facade = new Facade();
        public ActionResult Index()
        {
            Facade facade = new Facade();
            var num = facade.nDeVagasDisponiveis();
            var valor = num.ToString();
            ViewBag.qntd = valor;
            
            return View();
        }


        public ActionResult buscarTicket(String codigo)
        {
            if (facade.codExiste(codigo) == true)
            {
                var v = facade.geTicket(codigo);
                var horaEntrada = v.dt_hr_entrada;
                var valor = facade.precoPagar(v.ticket);
                ViewBag.preco = valor;
                ViewBag.date = horaEntrada;
                ViewBag.code = codigo;
                var barCode = bdf.Draw(codigo, 50);
                var imgString = facade.geraCodigoDeBarrasTM(barCode);
                ViewBag.codigoDeBarras = imgString;
                return View();

            }
            else
            {
                return PartialView("CodInvalido");
            }

        }

        public ActionResult retornaBuscarTicket()
        {
            return View("About");
        }

        public ActionResult About()
        {
//            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}