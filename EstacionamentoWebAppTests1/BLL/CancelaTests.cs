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
    public class CancelaTests
    {
        Cancela c = new Cancela();
        [TestMethod()]
        public void emiteTicketTest()
        {
            Console.Write( c.emiteTicket());
        }
    }
}