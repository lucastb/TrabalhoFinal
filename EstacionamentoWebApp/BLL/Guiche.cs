using PL.Model.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PL.DAO;

namespace EstacionamentoWebApp.BLL
{
    public class Guiche
    {
        CalculadorDePrecos cp;
        InteracaoEstacionamentoComCFG cfg;
        BarCodeGeneratorTM bcg;
        GeradorDeDataTM clock;
        InteracaoUsuarioEstacionamento yareYare;
        Estacionamento ticketEmitir;
        IntercaoMotivos im;
        EstacionamentoDAOImpl estDAO;
        




        public Guiche()
        {
            im = new IntercaoMotivos();
            cfg = new InteracaoEstacionamentoComCFG();
            cp = new CalculadorDePrecos();
            bcg = new BarCodeGeneratorTM();
            clock = new GeradorDeDataTM();
            yareYare = new InteracaoUsuarioEstacionamento();
            ticketEmitir = new Estacionamento();
            estDAO = new EstacionamentoDAOImpl();
        }

        public string geraCodespecial()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[5];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;        
    }

        public string emiteTicketCasoExtravio(Boolean extravio)
        {
            string dataEmissao = clock.now();
            ticketEmitir.ticket = bcg.generateCode();
            ticketEmitir.dt_hr_entrada = clock.HoraCustom(dataEmissao);
            ticketEmitir.emitido_por = "Guichê";
            ticketEmitir.valor_pago = 0.0;
            ticketEmitir.Liberado = false;
            if(extravio == true)
            {
                ticketEmitir.CodEspecial = "TKEXT";
            }
            else { ticketEmitir.CodEspecial = geraCodespecial(); }

            while(cfg.codExiste(ticketEmitir.ticket) == true)
            {
                ticketEmitir.ticket = bcg.generateCode();
            }
            if (cfg.ocupaVaga(ticketEmitir) == true)
            {
                return ticketEmitir.ticket;
            }
            else{ return "cheio"; }            
        }

        public double valorPagar(string cod)
        {
            var res = cfg.codExiste(cod);
            if(res == false)
            {
                return -1;
            }

            return cp.calculaPreco(cod);

        }
        
        public void liberaTicketPorPagamento(string cod)
        {
                var ticket = yareYare.getVagaPeloTicket(cod);
                var divida = valorPagar(cod);
                cfg.liberaTicket(ticket);
                cp.alteraPrecoPagar(cod, divida);
        }
        
        public void liberaSPagamento(string cod, int id)
        {
            var vaga = yareYare.getVagaPeloTicket(cod);
            estDAO.modificarValorAPagar(vaga, 0.0);
            estDAO.liberacaoEspecial(vaga, im.getMotById(id).motivo);
            estDAO.liberaTicket(vaga);
        }

        public void ativaMotivo(string nome)
        {
            var motivos = im.getMotivos();
            MotivosLiberacao aux = new MotivosLiberacao();
            foreach(MotivosLiberacao reasons in motivos)
            {
                if (reasons.motivo.Equals(nome)){
                    aux = reasons;
                }
            }
            im.ativa(aux);
        }

        public void desativaMotivos()
        {
            im.desativaTodos();
        }


    }
}