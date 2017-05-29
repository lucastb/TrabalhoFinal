using Microsoft.VisualStudio.TestTools.UnitTesting;
using EstacionamentoWebApp.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamentoWebApp.Controllers;
using PL.Model.POCO;
using System.Globalization;
using PL.DAO;

namespace EstacionamentoWebApp.BLL.Tests
{
    [TestClass()]
    public class InteracaoEstacionamentoComCFGTests
    {
        InteracaoEstacionamentoComCFG intercfg = new InteracaoEstacionamentoComCFG();
        GeradorDeDataTM tm = new GeradorDeDataTM();
        BarCodeGeneratorTM bcg = new BarCodeGeneratorTM();
        EstacionamentoDAOImpl estdao = new EstacionamentoDAOImpl();

        #region Testes de EstacionamentoDAo
        //[TestMethod()]
        //public void qntdTest()
        //{
        //    Console.WriteLine(intercfg.getVagasDisponiveis());
        //    //var vaga = estdao.GetEstacionamentoByID("GYtZ6oZOsJC");
        //    //estdao.mudarHoraDeSaida(vaga, DateTime.Parse(tm.now(), new CultureInfo("en-US")));
        //   // Console.WriteLine(intercfg.getVagasDisponiveis());
        //    //Assert.Fail();
        //}

        //[TestMethod()]
        //public void AddTest()
        //{
        //    Estacionamento esTest = new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.Parse(tm.now(), new CultureInfo("en-US")), emitido_por = "teste", valor_pago = 0.0, liberacao_especial = "teste" };
        //    var logica = estdao.Add(esTest);
        //    Console.WriteLine(logica);
        //    Console.WriteLine(intercfg.getVagasDisponiveis());
        //    //Assert.Fail();
        //}



        //[TestMethod()]
        //public void AddRepetidoTest()
        //{
        //    Estacionamento esTest = new Estacionamento { ticket = "FGEMKN4M1MB", dt_hr_entrada = DateTime.Parse(tm.now(), new CultureInfo("en-US")), dt_hr_saida = DateTime.Parse(tm.now(), new CultureInfo("en-US")), emitido_por = "teste", valor_pago = 0.0, liberacao_especial = "teste" };
        //    var logica = estdao.Add(esTest);
        //    Console.WriteLine(logica);

        //}

        //[TestMethod()]
        //public void validaTicket()
        //{
        //    var logicaVDD = estdao.validaTicket("FGEMKN4M1MB");
        //    var logicaFalsa = estdao.validaTicket("TRISTEZA");
        //    Console.WriteLine(logicaVDD);
        //    Console.WriteLine(logicaFalsa);
        //}

        //[TestMethod()]
        //public void mudarTudo()
        //{
        //    var qntd = intercfg.getVagasDisponiveis();
        //    Console.WriteLine(qntd);
        //    var vaga = estdao.GetEstacionamentoByID("gUIE9GhWFBt");
        //    estdao.modificarValorAPagar(vaga, 50);
        //    estdao.emitidoPor(vaga, "testeEmitido");
        //    estdao.mudarHoraDeSaida(vaga, DateTime.Parse(tm.now(), new CultureInfo("en-US")));
        //    estdao.liberacaoEspecial(vaga, "liberacao Teste");
        //    qntd = intercfg.getVagasDisponiveis();
        //    Console.WriteLine(qntd);
        //    //gUIE9GhWFBt

        //}
        #endregion

        #region interacaoCFGeEst
        //[TestMethod()]
        //public void ocupaVaga()
        //{
        //    Estacionamento esTest = new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.Parse(tm.now(), new CultureInfo("en-US")), emitido_por = "Testar intercaoCFG", valor_pago = 0.0, liberacao_especial = "teste interacao" };

        //    var logica = intercfg.ocupaVaga(esTest);
        //    Console.WriteLine(logica);
        //}

        //[TestMethod()]
        //public void ocupaVagaFalse()
        //{
        //    Estacionamento esTest = new Estacionamento { ticket = "FGEMKN4M1MB", dt_hr_entrada = DateTime.Parse(tm.now(), new CultureInfo("en-US")), emitido_por = "Testar intercaoCFG", valor_pago = 0.0, liberacao_especial = "teste interacao" };
        //    //por ser igual, gera outro codigo, dai fica true e insere, ou seja, funciona
        //    var logica = intercfg.ocupaVaga(esTest);
        //    Console.WriteLine(logica);
        //}
        //public void getQuantidade()
        //{
        //    Console.WriteLine(intercfg.getVagasDisponiveis());
        //}
        #endregion
       
    }
}