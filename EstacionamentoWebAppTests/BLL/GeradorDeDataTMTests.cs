using Microsoft.VisualStudio.TestTools.UnitTesting;
using EstacionamentoWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL.DAO;

namespace EstacionamentoWebApp.Controllers.Tests
{
    [TestClass()]
    public class GeradorDeDataTMTests
    {
        GeradorDeDataTM gera = new GeradorDeDataTM();
        EstacionamentoDAOImpl dao = new EstacionamentoDAOImpl();
        [TestMethod()]
        public void diferencaMinutosTest()
        {
          var horas =  gera.diferencaHoras(DateTime.Now, dao.GetEstacionamentoByID("CORTESIA").dt_hr_entrada);
            Console.WriteLine(horas);
        }
    }
}