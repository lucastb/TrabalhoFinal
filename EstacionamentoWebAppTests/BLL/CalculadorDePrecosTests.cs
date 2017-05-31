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
        //    string format = "MM-dd-yyyy HH:mm:ss";

        //    //FGEMKN4M1MB
        //    //gUIE9GhWFBt
        //    // var vaga = estdao.GetEstacionamentoByID("FGEMKN4M1MB");
        //    var passado = "08-08-2020 11:11:11";
        //    //Estacionamento estacionamentoTempoZero = new Estacionamento { ticket = "ATUAL", dt_hr_entrada = DateTime.ParseExact(tm.now(), format, new CultureInfo("en-US")), emitido_por = "TESTER O TROCO Q CHECA TEMPO", dt_hr_saida = DateTime.ParseExact(tm.now(), format, new CultureInfo("en-US")), valor_pago = 0.0, liberacao_especial = "testecALC" };
        //    //Estacionamento viajanteNoTempo = new Estacionamento { ticket = "FUTURO", dt_hr_entrada = DateTime.ParseExact(passado, format, new CultureInfo("en-US")), emitido_por = "passado",  valor_pago = 0.0, liberacao_especial = "testecALC" };
        //    //intcfg.ocupaVaga(viajanteNoTempo);
        //    //intcfg.ocupaVaga(estacionamentoTempoZero);
        //    int tempoIgual = 99;
        //    tempoIgual = calcP.checaTempo("ATUAL");
        //    int tempoFUTURO = calcP.checaTempo("FUTURO");
        //    int tempoNormal = calcP.checaTempo("nYyD3BU0HI8");
        //    Console.WriteLine(tempoIgual);
        //    Console.WriteLine(tempoFUTURO);
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

        //[TestMethod()]
        //public void checaPernoite()
        //{
        //    //string format = "MM-dd-yyyy HH:mm:ss";


        //    //var passado = "08-08-2020 01:59:59";
        //    // Estacionamento estacionamentoTempoZero = new Estacionamento { ticket = "ATUAL2", dt_hr_entrada = DateTime.ParseExact(tm.now(), format, new CultureInfo("en-US")), emitido_por = "TESTER O TROCO Q CHECA TEMPO", dt_hr_saida = DateTime.ParseExact(tm.now(), format, new CultureInfo("en-US")), valor_pago = 0.0, liberacao_especial = "testecALC" };
        //    //Estacionamento viajanteNoTempo = new Estacionamento { ticket = "FUTURO", dt_hr_entrada = DateTime.ParseExact(passado, format, new CultureInfo("en-US")), emitido_por = "passado",  valor_pago = 0.0, liberacao_especial = "testecALC" };
        //    //intcfg.ocupaVaga(estacionamentoTempoZero);
        //    //intcfg.ocupaVaga(estacionamentoTempoZero);
        //    //int tempoIgual = 99;
        //    //tempoIgual = calcP.checaTempo("ATUAL");
        //    //int tempoFUTURO = calcP.checaTempo("FUTURO");
        //    //int tempoNormal = calcP.checaTempo("nYyD3BU0HI8");
        //    Boolean var1 = calcP.checaPernoite("2");
        //    Boolean var2 = calcP.checaPernoite("3");
        //    int hum2 = calcP.checaTempo("2");
        //    int hum = calcP.checaTempo("3");
        //    // Console.WriteLine(tm.diferencaHoras(DateTime.Now, estdao.GetEstacionamentoByID("4").dt_hr_entrada));
        //    Console.WriteLine(hum2);
        //    Console.WriteLine(var1);
        //    Console.WriteLine(hum);
        //    Console.WriteLine(var2);
        //}

    }
}
    
