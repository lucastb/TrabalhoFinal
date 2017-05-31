using PL.Model.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoWebApp.BLL
{
    public class Cancela
    {
        Estacionamento vaga;
        BarCodeGeneratorTM bcg;
        InteracaoEstacionamentoComCFG estacionamento;
        GeradorDeDataTM clock;
        
        public Cancela()
        {
            vaga = new Estacionamento();
            bcg = new BarCodeGeneratorTM();
            estacionamento = new InteracaoEstacionamentoComCFG();
            clock = new GeradorDeDataTM();
        }
        

        public string emiteTicket()
        {
            if (estacionamento.aberto() == false)
            {
                return "Estacionamento fechado";
            }

            if (estacionamento.getVagasDisponiveis() > 0)
            {
                vaga.ticket = bcg.generateCode();

                while(estacionamento.codRepetido(vaga.ticket) == true)
                {
                    vaga.ticket = bcg.generateCode();
                }
               
                vaga.dt_hr_entrada = clock.HoraCustom(clock.now());
                vaga.emitido_por = "Cancela";
                vaga.Liberado = false;
                vaga.valor_pago = 0.0;
                estacionamento.ocupaVaga(vaga);
                return vaga.ticket;
                
            }

            return "Estacionamento lotado";
        }

    }
}