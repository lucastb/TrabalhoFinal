using PL.Model.POCO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace EstacionamentoWebApp.BLL

{
    public class GeradorDeDataTM
    {
        public Mes m = new Mes();

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
            int dias = 0;
            if(DateTime.Now.Hour >= 2)
            {
                dias = (int)diasDouble;
               dias = dias + 1;
                return dias;


            }
             dias = (int)diasDouble;
            return dias;
        }

        public int diferencaHoras(DateTime hoje, DateTime diaEntrada)
        {
            var horasDouble = (hoje - diaEntrada).TotalHours;
            int horas = (int)horasDouble;
            return horas;
        }

        public IEnumerable<Mes> meses()
        {
            var list = m.getMeses();
            return list;
        }

        public bool diaValidoParaDadoMes(string dia, string mesEscolhido)
        {
            int numeroMes = getnMesPorNomeMes(mesEscolhido);
            int diaConvertido = Int32.Parse(dia);
            if(numeroMes == 1 || numeroMes ==  3 || numeroMes == 5 || numeroMes == 7 || numeroMes == 8|| numeroMes == 10 || numeroMes == 12)
            {
                if(diaConvertido < 32)
                {
                    return true;
                }
                return false;

            }
            else if(numeroMes == 4 || numeroMes == 6 || numeroMes == 9 || numeroMes == 11)
            {
                if(diaConvertido < 31)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if(numeroMes == 2)
                {
                    if(diaConvertido < 30)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public int getMes(DateTime? dt)
        {
            int aux = dt.Value.Month;
            return aux;
        }

        //public int getDia(DateTime dataTicket)
        //{
        //    int aux = dt.Value.Day;
        //    return aux;
        //}

        public int getnMesPorNomeMes(string nome)
        {
            return m.getnMesPorNomeMes(nome);             
        }




    }
}