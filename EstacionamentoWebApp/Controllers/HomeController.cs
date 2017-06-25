
using EstacionamentoWebApp.BLL;
using EstacionamentoWebApp.Models;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Zen.Barcode;

namespace EstacionamentoWebApp.Controllers
{
    public class HomeController : Controller
    {
        private Code128BarcodeDraw bdf = BarcodeDrawFactory.Code128WithChecksum;
        private Facade facade = new Facade();


        //OK
        //1 - Número de vagas disponíveis. Como o estacionamento possui um número máximo de vagas, o sistema
        //deve ser capaz de informar o número atual de vagas livres
        public ActionResult Index()
        {
            var num = facade.nDeVagasDisponiveis();
            ViewBag.qntd = num;
            
            return View();
        }

        //API
        public ActionResult getValorDeVagasPelaAPI()
        {
            return Redirect("/api/FacadeAPi");
        }

        public ActionResult buscarTicketAPi(string cod)
        {
            return Redirect("/api/PrecoAPI/" + cod);            
        }

        //OK
        //2 - Consulta do valor a ser pago pelo ticket do estacionamento. Com base no número de identificação, o
        //sistema deve fornecer o valor atual a ser pago para a liberação do ticket de estacionamento.
        public ActionResult buscarTicket(String codigo)
        {
            if (facade.codExiste(codigo) == true)
            {
                var v = facade.geTicket(codigo);
                if (v.dt_hr_saida != null)
                {
                    ViewBag.jaSaiu = "Ticket já deixou o estacionamento";
                    return View("JaValidado");
                }                
                if (v.valor_pago > 0)
                {
                    ViewBag.pago = "Ticket Pago";
                    return View("JaValidado");                 
                }
                if (v.Liberado == true)
                {
                    ViewBag.lin = "Ticket já liberado para saída!";
                    return View("JaValidado");

                }

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


        //OK
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

        
        public ActionResult CancelaSaida()
        {
            return View();
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


        //OK
        //4 - cancela de saida
        //        O sistema deve permitir os seguintes casos de uso por parte da cancela de saída(o sistema permite dois modos de
        //funcionamento):
        // Validação de ticket para liberação da cancela.O sistema deve receber o número do ticket e verificar se o
        //mesmo está liberado a fim da cancela ser aberta.
        //Liberação de todos os tickets. Em casos determinados pela gerência do estabelecimento (emergências ou
        //eventos especiais, por exemplo), a cancela é liberada de forma independente do status do ticket.Neste
        //caso, o sistema deve armazenar a informação do motivo de liberação do ticket(os possíveis motivos são
        //pré-definidos).

        public ActionResult validarSaida(String codigo)
        {
            var res = facade.validarTicketParaSaida(codigo);
            switch (res)
            {
                case -1:
                    ViewBag.especial = "Saída Liberada! \nLiberação especial";
                    return View("~/Views/CancelaSaida/SaidaLiberada.cshtml");

                case 0:
                    return PartialView("~/Views/Home/CodInvalido.cshtml");
                    
                case 1:
                    ViewBag.saida = "Saída Liberada! \nObrigado!";
                    return View("~/Views/CancelaSaida/SaidaLiberada.cshtml");

                case 2:
                    ViewBag.cortesia = "Cortesia! \nSaída Liberada!";
                    return View("~/Views/CancelaSaida/SaidaLiberada.cshtml");

                case 3:
                    ViewBag.nPago = "Ticket não pago!";
                    ViewBag.valor = facade.precoPagar(codigo);
                    return View("~/Views/CancelaSaida/NPago.cshtml");

                case 4:
                    return View("~/Views/CancelaSaida/Erro.cshtml");

                case 5:
                    return View("~/Views/CancelaEntrada/Fechado.cshtml");

                case 7:
                    ViewBag.jaSaiu = "Ticket já deixou o estacionamento";
                    return View("JaValidado");
            }
            return View("~/Views/CancelaSaida/Erro.cshtml");
        }

        //public ActionResult LibEmergencial(string cod)
        //{
        //    if(facade.codExiste(cod) == false)
        //    {
        //        return PartialView("~/Views/Home/CodInvalido.cshtml");
        //    }

        //    if (facade.liberacaoEmergencialFacade(cod) == true)
        //    {
        //        ViewBag.lEspecial = facade.geTicket(cod).liberacao_especial;
        //        return View("~/Views/CancelaSaida/SaidaLiberada.cshtml");
        //    }
        //    else
        //    {
        //        return View("~/Views/CancelaSaida/LiberacaoEspFalse.cshtml");
                
        //    }
        //}


    }
}
