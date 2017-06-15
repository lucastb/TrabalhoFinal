using EstacionamentoWebApp.BLL;
using PL.Model.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstacionamentoWebApp.Controllers
{
    public class AdministrativoController : Controller
    {
        private Facade f = new Facade();
        // GET: Administrativo
        [Authorize(Users = "admin@psa.br")]
        public ActionResult Index(string mesEscolhido, string diaEscolhido)
        {
            var listaTotalDeTickets = f.getTicketsPagos();
            var listAux = f.filtrar(listaTotalDeTickets, diaEscolhido, mesEscolhido);
            ViewBag.valorT = f.getValorTotalPago(listAux);
            return View(listAux);
        }



        [Authorize(Users = "admin@psa.br")]
        public ActionResult nTicketsPagos(string mesEscolhido, string diaEscolhido)
        {
            var listaTotalDeTickets = f.getTicketsPagos();
            var listAux = f.filtrar(listaTotalDeTickets, diaEscolhido, mesEscolhido);
            ViewBag.qntd = f.nDeTicketsPagosTotal(listAux);
            return View(listAux);
        }

        [Authorize(Users = "admin@psa.br")]
        public ActionResult ticketsLiberadoSemPagamento(string mesEscolhido, string diaEscolhido)
        {
            var listaNPaga = f.getTicketsNPagos();
            var listAux = f.filtrar(listaNPaga, diaEscolhido, mesEscolhido);
            ViewBag.qntd = f.nDeTicketsPagosTotal(listAux);

            return View(listAux);
        }


    }
}
////public ViewResult Administrativo(string searchString, string sortOrder, int? SelectedDate)
////{
////    var tickets = f.getListaDeTickets();

////    //var meses = f.getMeses().OrderBy(m => m.nMes).ToList();

////    //ViewBag.SelectedDate = new SelectList(meses, "nMes", "NomeMes", SelectedDate);
////    //int nMes = SelectedDate.GetValueOrDefault();

////    //var vagas = f.getListaDeTickets().OrderBy(vl => vl.valor_pago).ToList()
////    //    .Where(t => !SelectedDate.HasValue || f.mes(t.dt_hr_saida) == nMes);

////    //if (!String.IsNullOrEmpty(searchString))
////    //{
////    //    vagas = vagas.Where(v => f.mes(v.dt_hr_saida) == f.NumeroMesPeloNome(searchString));
////    //}
////    return View(tickets);
////    //ViewBag.preco == sortOrder == "Valor" ? "valor_asc" : "valor_desc";
////}
