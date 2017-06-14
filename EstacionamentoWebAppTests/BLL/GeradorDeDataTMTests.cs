using Microsoft.VisualStudio.TestTools.UnitTesting;
using EstacionamentoWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL.DAO;
using PL.Model.POCO;
using System.Globalization;
using EstacionamentoWebApp.BLL;

namespace EstacionamentoWebApp.Controllers.Tests
{

    [TestClass()]
    public class GeradorDeDataTMTests
    {
        GeradorDeDataTM gera = new GeradorDeDataTM();
        EstacionamentoDAOImpl dao = new EstacionamentoDAOImpl();

        //[TestMethod()]
        //public void diferencaMinutosTest()
        //{
        //  var horas =  gera.diferencaHoras(DateTime.Now, dao.GetEstacionamentoByID("CORTESIA").dt_hr_entrada);
        //    Console.WriteLine(horas);
        //}

        
        //    [TestMethod()]
        //    public void horaCustom()
        //    {
        //        DateTime data=  gera.HoraCustom("08-21-1995 02:59:00");
        //        //var vaga = dao.GetEstacionamentoByID("udzMwOdiJOb");
        //        //dao.mudarHoraDeSaida(vaga, data);
               
        //        Console.WriteLine(data);
        //    }

        //[TestMethod()]
        //public void HoraTeste()
        //{
        //   // string format = "MM-dd-yyyy HH:mm:ss";

        //    //Estacionamento esTest = new Estacionamento { ticket = "COMPARAHORAS", dt_hr_entrada = DateTime.ParseExact(gera.now(), format, new CultureInfo("en-US")),  emitido_por = "teste", valor_pago = 0.0, liberacao_especial = "teste" };
        //    //dao.Add(esTest);
        //    var hora = dao.GetEstacionamentoByID("COMPARAHORAS").dt_hr_entrada.Hour;
        //    Console.WriteLine(hora);
        //}

        [TestMethod()]
        public void TesteMinutos()
        {
            var vaga = dao.GetEstacionamentoByID("12W");
            var vaga2 = dao.GetEstacionamentoByID("ASD");
            //var diasDouble = (hoje - diaEntrada).TotalDays;

            //Console.WriteLine(gera.diferencaMinutos(DateTime.Now, vaga.dt_hr_entrada));
            //Console.WriteLine(gera.diferencaDias(DateTime.Now, vaga2.dt_hr_entrada));
            Console.WriteLine((DateTime.Now - vaga2.dt_hr_entrada).TotalDays);


        }

    }
}