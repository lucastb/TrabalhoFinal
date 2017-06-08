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
    public class IntercaoMotivosTests
    {
        IntercaoMotivos m = new IntercaoMotivos();
        //[TestMethod()]
        //public void IntercaoMotivosTest()
        //{
        //    m.ativa(m.getMotById(2));
        //}

        //public void desativa()
        //{
        //    //m.desativa(m.getMotById(2));
        //}

        [TestMethod()]
        public void desativaTodos()
        {
            m.desativaTodos();
        }
    }
}