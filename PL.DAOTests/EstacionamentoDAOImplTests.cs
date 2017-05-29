using EstacionamentoWebApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PL.DAO;
using PL.Model.POCO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.DAO.Tests
{
    [TestClass()]
    public class EstacionamentoDAOImplTests
    {
        EstacionamentoDAOImpl estdao = new EstacionamentoDAOImpl();
        [TestMethod()]
        public void AddTest()
        {
            GeradorDeDataTM tm = new GeradorDeDataTM();
            BarCodeGeneratorTM bcg = new BarCodeGeneratorTM();
           Estacionamento esTest =  new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.Parse(tm.now(), new CultureInfo("en-US")), dt_hr_saida = DateTime.Parse(tm.now(), new CultureInfo("en-US")), emitido_por = "teste", valor_pago = 0.0, liberacao_especial = "teste" };
            var logica = estdao.Add(esTest);
            Console.WriteLine(logica);
            //Assert.Fail();
        }
    }
}