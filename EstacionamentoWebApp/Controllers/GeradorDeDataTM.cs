using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoWebApp.Controllers
{
    public class GeradorDeDataTM
    {
        public string now()
        {
            DateTime time = DateTime.Now;
            string format = "MM-dd-yyyy HH:mm:ss";
            string Jikan = time.ToString(format);
            return Jikan;
        }
        //não foi testado
        public string HoraCustom(DateTime zaWarudo)
        {
            string format = "dd-MM-yyyy HH:mm:ss";
            var lambda = zaWarudo.ToString(format);
            return lambda;
        }


       
    }
}