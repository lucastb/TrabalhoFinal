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
        GeradorDeDataTM tm = new GeradorDeDataTM();
        BarCodeGeneratorTM bcg = new BarCodeGeneratorTM();
        EstacionamentoDAOImpl estdao = new EstacionamentoDAOImpl();
        CalculadorDePrecos calcP = new CalculadorDePrecos();
        InteracaoEstacionamentoComCFG intcfg = new InteracaoEstacionamentoComCFG();


        #region TestaDiagnosticoTemporal
        //[TestMethod()]
        //public void checaTempoTest()
        //{

        //    //FGEMKN4M1MB
        //    //gUIE9GhWFBt
        //    // var vaga = estdao.GetEstacionamentoByID("FGEMKN4M1MB");
        //    var passado = "08-08-2020";
        //    Estacionamento estacionamentoTempoZero = new Estacionamento { ticket = "ATUAL", dt_hr_entrada = DateTime.Parse(tm.now(), new CultureInfo("en-US")), emitido_por = "TESTER O TROCO Q CHECA TEMPO", dt_hr_saida = DateTime.Parse(tm.now(), new CultureInfo("en-US")), valor_pago = 0.0, liberacao_especial = "testecALC" };
        //    Estacionamento viajanteNoTempo = new Estacionamento { ticket = "FUTURO", dt_hr_entrada = DateTime.Parse(passado, new CultureInfo("en-US")), emitido_por = "passado", dt_hr_saida = DateTime.Parse(passado, new CultureInfo("en-US")), valor_pago = 0.0, liberacao_especial = "testecALC" };
        //    intcfg.ocupaVaga(viajanteNoTempo);
        //    intcfg.ocupaVaga(estacionamentoTempoZero);
        //    int tempoIgual = 99;
        //    tempoIgual = calcP.checaTempo("ATUAL");
        //    int tempoPassado = calcP.checaTempo("FUTURO");
        //    int tempoNormal = calcP.checaTempo("FGEMKN4M1MB");
        //    Console.WriteLine(tempoIgual);
        //    Console.WriteLine(tempoPassado);
        //    Console.WriteLine(tempoNormal);
        //}
        #endregion

        #region Cortesia
        //[TestMethod()]
        //public void cortesia()
        //{
        //    string hora = "05-29-2017 02:30:30";
        //    Estacionamento cortesia = new Estacionamento { ticket = "CORTESIA falsa", dt_hr_entrada = DateTime.Parse(hora, new CultureInfo("en-US")), emitido_por = "TESTER kek", valor_pago = 0.0, liberacao_especial = "testecALC" };
        //    // Estacionamento cortesia = new Estacionamento { ticket = "CORTESIA", dt_hr_entrada = DateTime.Parse(tm.now(), new CultureInfo("en-US")), emitido_por = "TESTER kek",  valor_pago = 0.0, liberacao_especial = "testecALC" };
        //    intcfg.ocupaVaga(cortesia);
        //    var boo = calcP.checaCortesia("CORTESIA falsa");
        //    Console.WriteLine(boo);
        //    Console.WriteLine(intcfg.getVagasDisponiveis());
        //}
        #endregion
    }
}
    
