using Microsoft.VisualStudio.TestTools.UnitTesting;
using EstacionamentoWebApp.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL.DAO;

namespace EstacionamentoWebApp.BLL.Tests
{
    [TestClass()]
    public class GeradorDeDataTMTests
    {
        [TestMethod()]
        public void diferencaDiasTest()
        {
            EstacionamentoDAOImpl ed = new EstacionamentoDAOImpl();
            GeradorDeDataTM clock = new GeradorDeDataTM();
            var ticket = ed.GetEstacionamentoByID("ASD");
            Console.WriteLine(ticket.dt_hr_entrada);

            //int dias = clock.diferencaDias(DateTime.Now, ticket.dt_hr_entrada);
            //Console.WriteLine(dias);
        }
    }
}