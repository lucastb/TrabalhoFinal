using EstacionamentoWebApp.BLL;
using PL.Model.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EstacionamentoWebApp.Controllers
{
    public class FacadeAPIController : ApiController
    {
        private Facade f = new Facade();

        //GET
        //[Route("api/FacadeAPI/qntd")]
        public string getQuantidadeVagasDisp()
        {
            var qntd = f.nDeVagasDisponiveis();
            return qntd.ToString() + " vagas disponíveis";
        }


    }
}
