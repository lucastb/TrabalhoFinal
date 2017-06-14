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
        public ActionResult Index(int mesEscolhido)
        {
            //GAMBIARRA FAM
            var ticket = f.getEstatacionamentosCSaida();
            var listAux = f.tryme(ticket, mesEscolhido);


            ViewBag.valorT = f.getValorTotalPago();

            return View(listAux);
        }






        public ActionResult nTicketsPagos()
        {
            return View();
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
