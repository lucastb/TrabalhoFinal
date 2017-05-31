using Microsoft.VisualStudio.TestTools.UnitTesting;
using EstacionamentoWebApp.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoWebApp.BLL.Tests
{
    [TestClass()]
    public class InteracaoUsuarioEstacionamentoTests
    {
        InteracaoUsuarioEstacionamento x = new InteracaoUsuarioEstacionamento();
        [TestMethod()]
        public void getVagaPeloTicketTest()
        {
            var y = x.getVagaPeloTicket("test");
            Console.WriteLine(y.EstacionamentoId);
            Console.WriteLine(y.ticket);
            Console.WriteLine(y.dt_hr_entrada);

//           Assert.Fail();
        }
    }
}