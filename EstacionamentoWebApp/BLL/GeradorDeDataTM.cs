using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace EstacionamentoWebApp.Controllers
{
    public class GeradorDeDataTM
    {
        public string now()
        {
            DateTime time = DateTime.Now;
            string format = "MM-dd-yyyy HH:mm:ss";
            string Jikan = time.ToString(format);
            return Jikan;
        }
       
       

        //não foi testado
        public DateTime HoraCustom(string zaWarudo)
        {
            DateTime lambda = DateTime.ParseExact(zaWarudo, "MM-dd-yyyy HH:mm:ss", new CultureInfo("en-US"));
            return lambda;
        }


        public DateTime data(string date)
        {
            DateTime medokuse = DateTime.Parse(date, new CultureInfo("en-US"));
            return medokuse.Date;
        }
        
        public int diferencaMinutos(DateTime hoje, DateTime diaEntrada)
        {
            var valor = (hoje - diaEntrada).TotalMinutes;
            int minutos = (int)valor;
            return minutos;
        }

        public int diferencaDias(DateTime hoje, DateTime diaEntrada)
        {
            var diasDouble = (hoje - diaEntrada).TotalDays;
            int dias = (int)diasDouble;
            return dias;
        }

        public int diferencaHoras(DateTime hoje, DateTime diaEntrada)
        {
            var horasDouble = (hoje - diaEntrada).TotalHours;
            int horas = (int)horasDouble;
            return horas;
        }

    }
}