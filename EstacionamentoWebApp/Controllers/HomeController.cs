
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



        //1 - Número de vagas disponíveis. Como o estacionamento possui um número máximo de vagas, o sistema
        //deve ser capaz de informar o número atual de vagas livres
        public ActionResult Index()
        {
            Facade facade = new Facade();
            var num = facade.nDeVagasDisponiveis();
            var valor = num.ToString();
            ViewBag.qntd = valor;
            
            return View();
        }


        //2 - Consulta do valor a ser pago pelo ticket do estacionamento. Com base no número de identificação, o
        //sistema deve fornecer o valor atual a ser pago para a liberação do ticket de estacionamento.
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


        //3 - Cancela
        //Emissão de ticket de estacionamento, contendo um código (passível de transformação para código de
        //barras ou qr-code), data e horário de entrada do automóvel.
        public ActionResult btnEmitirTicketEntrada()
        {
            var res = facade.cancelaEmiteTicket();
            if (res != "Estacionamento fechado" && res != "Estacionamento lotado")
            {
                var aux = facade.geTicket(res);
                ViewBag.date = aux.dt_hr_entrada;
                ViewBag.code = aux.ticket;
                ViewBag.codigoDeBarras = facade.geraCodigoDeBarrasTM(bdf.Draw(aux.ticket, 50));
                return View("~/Views/CancelaEntrada/TicketEmitidoCancelaDeEntrada.cshtml");
            }
            else if(res.Equals("Estacionamento lotado"))
            {return View("~/Views/CancelaEntrada/Lotado.cshtml"); }
            else { return View("~/Views/CancelaEntrada/Fechado.cshtml"); }
            }

        



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult About()
        {
            //            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}