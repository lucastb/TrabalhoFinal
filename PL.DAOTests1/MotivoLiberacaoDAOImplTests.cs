using Microsoft.VisualStudio.TestTools.UnitTesting;
using PL.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.DAO.Tests
{
    [TestClass()]
    public class MotivoLiberacaoDAOImplTests
    {
        [TestMethod()]
        public void alteraStatusAtivadoTest()
        {
            MotivoLiberacaoDAOImpl m = new MotivoLiberacaoDAOImpl();
            m.alteraStatusAtivado(m.getMotivoById(2));
        }
    }
}