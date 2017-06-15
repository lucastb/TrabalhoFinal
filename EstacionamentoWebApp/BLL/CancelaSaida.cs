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
        IntercaoMotivos im;


        public CancelaSaida()
            {
                calc = new CalculadorDePrecos();
                est = new EstacionamentoDAOImpl();
                datador = new GeradorDeDataTM();
                estcfg = new InteracaoEstacionamentoComCFG();
                im = new IntercaoMotivos();
            }

            public int liberaSaida(string cod)
            {

            if(estcfg.aberto() == false)
            {
                return 5;
            }

              if(estcfg.codExiste(cod) == false)
            {
                return 0;
            }

            var ticket = est.GetEstacionamentoByID(cod);

            if(im.temAtivado() == true)
            {
                var motivo = im.motivo();
                est.liberacaoEspecial(ticket, motivo);
                est.liberaTicket(ticket);
                est.modificarValorAPagar(ticket, 0.0);
                est.mudarHoraDeSaida(ticket, DateTime.Now);
                return -1;
            }

            if(est.GetEstacionamentoByID(cod).CodEspecial != null)
            {
                //if(ticket.dt_hr_saida != )
                if (ticket.Liberado == true)
                {
                    est.mudarHoraDeSaida(ticket, DateTime.ParseExact(datador.now(), "MM-dd-yyyy HH:mm:ss", new CultureInfo("en-US")));
                    return 1;
                }else { return 3; }
            }else if (calc.checaCortesia(cod) == false){

                if(ticket.Liberado == true)
                {
                    est.mudarHoraDeSaida(ticket, DateTime.ParseExact(datador.now(), "MM-dd-yyyy HH:mm:ss", new CultureInfo("en-US")));
                    return 1;

                }else if(ticket.Liberado == false) {return 3;}
                }else{
                    double valor = 0.0;
                    string motivo = "Cortesia";
                    est.modificarValorAPagar(ticket, valor);
                    est.liberacaoEspecial(ticket, motivo);
                    est.mudarHoraDeSaida(ticket, DateTime.ParseExact(datador.now(), "MM-dd-yyyy HH:mm:ss", new CultureInfo("en-US")));
                est.liberaTicket(ticket);
                    return 2;
                }
            return 4;
            }

       
        }
      }
    

