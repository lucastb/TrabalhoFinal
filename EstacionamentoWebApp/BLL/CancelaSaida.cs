using PL.DAO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EstacionamentoWebApp.BLL
{
    public class CancelaSaida
    {
        CalculadorDePrecos calc;
        EstacionamentoDAOImpl est;
        GeradorDeDataTM datador;
        InteracaoEstacionamentoComCFG estcfg;


            public CancelaSaida()
            {
                calc = new CalculadorDePrecos();
                est = new EstacionamentoDAOImpl();
                datador = new GeradorDeDataTM();
                estcfg = new InteracaoEstacionamentoComCFG();
            }

            public int liberaSaida(string cod)
            {
              if(estcfg.codExiste(cod) == false)
            {
                return 0;
            }

            var ticket = est.GetEstacionamentoByID(cod);

                if (calc.checaCortesia(cod) == false)
                {
                if(ticket.Liberado == true)
                {
                    est.mudarHoraDeSaida(ticket, DateTime.Parse(datador.now(), new CultureInfo("en-US")));
                    return 1;

                }else if(ticket.Liberado == false) {return 3;}
                }else{
                    double valor = 0.0;
                    string motivo = "Cortesia";
                    est.modificarValorAPagar(ticket, valor);
                    est.liberacaoEspecial(ticket, motivo);
                    est.mudarHoraDeSaida(ticket, DateTime.Parse(datador.now(), new CultureInfo("en-US")));
                    est.liberaTicket(ticket);
                    return 2;
                }
            return 4;
            }

        public Boolean liberacaoEmergencial(string motivo, string cod)
        {
            if(estcfg.codExiste(cod) == false)
            {
                return false;
            }else
            {
                var ticket = est.GetEstacionamentoByID(cod);
                var valor = 0.0;
                est.modificarValorAPagar(ticket, valor);
                est.liberacaoEspecial(ticket, motivo);
                est.mudarHoraDeSaida(ticket, DateTime.Parse(datador.now(), new CultureInfo("en-US")));
                est.liberaTicket(ticket);
                return true;
            }
        }
        }
    }

