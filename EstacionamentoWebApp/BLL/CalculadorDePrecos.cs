using PL.DAO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using PL.Model.POCO;

namespace EstacionamentoWebApp.BLL
{
    public class CalculadorDePrecos
    {
        EstacionamentoDAOImpl estDAO;
        GeradorDeDataTM clock;
        CfgDAOImpl cfg;
        InteracaoEstacionamentoComCFG intcfg;
        int horaEncerramento;
        int horaAbertura;
        



        public CalculadorDePrecos()
        {
            estDAO = new EstacionamentoDAOImpl();
            clock = new GeradorDeDataTM();
            cfg = new CfgDAOImpl();
            intcfg = new InteracaoEstacionamentoComCFG();
            horaEncerramento = cfg.GetConfiguracao().horaEncerrameto.Hour;
            horaAbertura = cfg.GetConfiguracao().horaAbertura.Hour;
        }

        public void alteraPrecoPagar(string cod, double valor)
        {
            estDAO.modificarValorAPagar(estDAO.GetEstacionamentoByID(cod), valor);
        }

        public Boolean checaCortesia(string cod)
        {
            var vaga = estDAO.GetEstacionamentoByID(cod);
            if (checaTempo(cod) == 0)
            {
                if (clock.diferencaMinutos(DateTime.Now, vaga.dt_hr_entrada) <= 15)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean checaPernoite(string cod)
        {

            var vaga = estDAO.GetEstacionamentoByID(cod);
            var amaterasu = checaTempo(cod);
            int horaEntrada = vaga.dt_hr_entrada.Hour;
            int minutoEntrada = vaga.dt_hr_entrada.Minute;
            int agora = DateTime.Now.Hour;


            ////para testar no lugar do 'agora'
            //string format = "MM-dd-yyyy HH:mm:ss"; //para teste
            //DateTime dummie = DateTime.ParseExact("05-30-2017 10:30:00", format, new CultureInfo("en-US")); //para teste
            //int dummieHora = dummie.Hour; //para teste
            if(clock.diferencaDias(DateTime.Now, vaga.dt_hr_entrada) > 1)
            {
                return true;
            }

            switch (amaterasu)
            {
                case 0:
                    if(horaEntrada >= 0 && horaEntrada <= 2)
                    {
                        if(agora >= horaAbertura)
                        {
                            return true;
                        }
                    }
                    return false;

                case 1:                    
                    if(agora < horaEncerramento)
                    {
                        return false;
                    }
                    return true;

                case -1:
                    Console.WriteLine("n faz sentido");
                    break;

                case 2:
                    Console.WriteLine("ERRO");
                    break;
            }

            return false;
        }


        public int checaTempo(string cod)
        {
            var dataVaga = estDAO.GetEstacionamentoByID(cod).dt_hr_entrada.Date;
            int ponderacao;
            var resultado = DateTime.Compare(DateTime.Now.Date, dataVaga);
            
            if (resultado < 0)
            {
                ponderacao = -1;
                return ponderacao;
            }

            if (resultado > 0)
            {
                ponderacao = 1;
                return ponderacao;
            }

            if (resultado == 0)
            {
                ponderacao = 0;
                return ponderacao;
            }

            return 2;

        }

        #region calcularPreco velho
        //ARRUMARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR
        //public double calculaPreco(string cod)
        //{
        //    var ticketObj = estDAO.GetEstacionamentoByID(cod);
        //    if (ticketObj.CodEspecial != null)
        //    {

        //        return cfg.GetConfiguracao().valorFixoExtravio; 
        //    }

        //    if (checaCortesia(cod) == true)
        //    {
        //        return 0;
        //    }

        //    double precoPagar = 0.0;            
        //    var ticket = estDAO.GetEstacionamentoByID(cod).dt_hr_entrada;
        //    var preco3Horas = cfg.GetConfiguracao().valorFixo3Horas;
        //    var precoPernoite = cfg.GetConfiguracao().valorFixoPernoite;
        //    var precoFixoAcima3Horas = cfg.GetConfiguracao().valorFixoAcima3Horas;


        //    if (checaPernoite(cod) == false)
        //    {
        //        var minutos = clock.diferencaMinutos(DateTime.Now, ticket);

        //        if (minutos <= 180)//menor ou igual 3 horas
        //        {
        //            precoPagar = preco3Horas;
        //            return precoPagar;
        //        }
        //        precoPagar = precoFixoAcima3Horas;
        //        return precoPagar;              
        //    }

        //    if(checaPernoite(cod) == true)
        //    {
        //        int dias = clock.diferencaDias(DateTime.Now, ticket);
        //        if(dias > 1)
        //        {
        //            precoPagar = precoPernoite * dias;
        //            return precoPagar;
        //        }
        //        precoPagar = precoPernoite;
        //        return precoPagar;

        //    }
        //        return -1;
        //}
        #endregion

        #region Métodos para calcular preço

        public double calculaPrecoDeTicketExtraviado(string cod)
        {
            double precoPagar = 0;
            var ticketObj = estDAO.GetEstacionamentoByID(cod);
            var precoFixoExtravio = cfg.GetConfiguracao().valorFixoExtravio;
            var ticket = ticketObj.dt_hr_entrada;

            if (checaPernoite(cod) == false)
            {
                return precoFixoExtravio;
            }else
                {
                var precoPernoite = cfg.GetConfiguracao().valorFixoPernoite;
                int dias = clock.diferencaDias(DateTime.Now, ticket);
                    if (dias > 1)
                    {
                        precoPagar = precoFixoExtravio + precoPernoite * dias;
                        return precoPagar;
                    }
                    precoPagar = precoPernoite + precoFixoExtravio;
                    return precoPagar;
                }
        }


        #region ticket n extraviado
        public double valorTicketSemPernoite(string cod)
        {
            double precoPagar = 0;
            var ticketObj = estDAO.GetEstacionamentoByID(cod);
            var ticket = ticketObj.dt_hr_entrada;
            var minutos = clock.diferencaMinutos(DateTime.Now, ticket);

            if (minutos <= 180)//menor ou igual 3 horas
            {
                var preco3Horas = cfg.GetConfiguracao().valorFixo3Horas;
                precoPagar = preco3Horas;
                return precoPagar;
            }
            else
            {
                var precoFixoAcima3Horas = cfg.GetConfiguracao().valorFixoAcima3Horas;
                precoPagar = precoFixoAcima3Horas;
                return precoPagar;
            }
        }

        public double valorTicketComPernoite(string cod)
        {
            double precoPagar = 0;
            var ticketObj = estDAO.GetEstacionamentoByID(cod);
            var ticket = ticketObj.dt_hr_entrada;
            var precoPernoite = cfg.GetConfiguracao().valorFixoPernoite;
            int dias = clock.diferencaDias(DateTime.Now, ticket);

            if (dias > 1)
            {
                precoPagar = precoPernoite * dias;
                return precoPagar;
            }
            else
            {
                precoPagar = precoPernoite;
                return precoPagar;
            }
        }
        #endregion

        #endregion

        public double calculaPreco(string cod)
        {
            var ticket = estDAO.GetEstacionamentoByID(cod);
            double valor = 0;
            if(ticket.CodEspecial != null)
            {
                valor = calculaPrecoDeTicketExtraviado(cod);
                return valor;
            }else
            {
                if(checaCortesia(cod) == true)
                {
                    return 0;
                }else
                {
                    if(checaPernoite(cod) == true)
                    {
                        valor = valorTicketComPernoite(cod);
                        return valor;
                    }else
                    {
                        valor = valorTicketSemPernoite(cod);
                        return valor;
                    }
                }
            }
        }



        public double valorTotalPago(IEnumerable<Estacionamento> listaTickets)
        {
            double valor = 0;
            foreach(Estacionamento est in listaTickets)
            {
                valor = valor + est.valor_pago;
            }
            return valor;
        }
    }
}