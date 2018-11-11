using Microsoft.VisualStudio.TestTools.UnitTesting;
using EstacionamentoWebApp.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL.Model.POCO;
using EstacionamentoWebApp.Controllers;
using System.Globalization;
using PL.DAO;

namespace EstacionamentoWebApp.BLL.Tests
{
    [TestClass()]
    public class CalculadorDePrecosTests
    {
        Facade f = new Facade();
        CalculadorDePrecos calcP = new CalculadorDePrecos();
        InteracaoEstacionamentoComCFG intcfg = new InteracaoEstacionamentoComCFG();
        EstacionamentoDAOImpl estDAO = new EstacionamentoDAOImpl();
        Cancela cancela = new Cancela();





        #region Calcular preço
        [TestMethod()]
        public void cortesia()
        {
            var cod = cancela.emiteTicket();
            var boo = calcP.checaCortesia(cod);
            Assert.AreEqual(true, boo);
            f.validarTicketParaSaida(cod);
        }
        #endregion

        //calcula valor com pernoite
        [TestMethod()]
        public void valorTicketComPernoiteTest()
        {
            //preço base da pernoite é predefinido por 50 reais
            //calculo é preçoBase * dias

            var cod = cancela.emiteTicket();
            var ticketObj = estDAO.GetEstacionamentoByID(cod);
            ticketObj.dt_hr_entrada = ticketObj.dt_hr_entrada.AddDays(-1);
            estDAO.SaveChanges();
            var boo = calcP.checaPernoite(cod);
            Assert.AreEqual(true, boo);
            double preco = calcP.valorTicketComPernoite(cod);
            //1 dia 
            Assert.AreEqual(50, preco);

            ticketObj.dt_hr_entrada = ticketObj.dt_hr_entrada.AddDays(-1);
            estDAO.SaveChanges();
            preco = calcP.valorTicketComPernoite(cod);
            //2 dias
            Assert.AreEqual(100, preco);
        }

        [TestMethod()]
        public void valorTicketSemPernoiteAte3Horas()
        {
            //preço base é calculado para até 3 horas
            //e passado de 3 horas
            var cod = cancela.emiteTicket();
            var ticketObj = estDAO.GetEstacionamentoByID(cod);
            ticketObj.dt_hr_entrada = ticketObj.dt_hr_entrada.AddHours(-2);
            estDAO.SaveChanges();
            var boo = calcP.checaPernoite(cod);
            Assert.AreEqual(false, boo);
            double preco = calcP.valorTicketSemPernoite(cod);
            //até 3 horas
            Assert.AreEqual(5, preco);           
        }

        [TestMethod()]
        public void valorTicketSemPernoitePassado3Horas()
        {
            //preço base é calculado para até 3 horas
            //e passado de 3 horas
            var cod = cancela.emiteTicket();
            var ticketObj = estDAO.GetEstacionamentoByID(cod);
            ticketObj.dt_hr_entrada = ticketObj.dt_hr_entrada.AddHours(-4);
            estDAO.SaveChanges();
            var boo = calcP.checaPernoite(cod);
            Assert.AreEqual(false, boo);
            double preco = calcP.valorTicketSemPernoite(cod);
            //até 3 horas
            Assert.AreEqual(20, preco);
        }
    }
}

