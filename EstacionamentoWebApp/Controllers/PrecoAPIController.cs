using EstacionamentoWebApp.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EstacionamentoWebApp.Controllers
{
    public class PrecoAPIController : ApiController
    {
        private Facade f = new Facade();

        //GET
        //CHAMAR COM: api/PrecoAPI/COGIO AQUI
        public string Get(string id)
        {
            if (f.codExiste(id) == false)
            {
                return "Not found";
            }

            var valorTicket = f.precoPagar(id);
            return "R$" + valorTicket.ToString() + ",00";

        }

    }
}
