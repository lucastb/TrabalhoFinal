using PL.Model.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoWebApp.BLL
{
    public class Guiche
    {
        CalculadorDePrecos cp;
        InteracaoEstacionamentoComCFG cfg;
        BarCodeGeneratorTM bcg;
        GeradorDeDataTM clock;
        InteracaoUsuarioEstacionamento yareYare;
        

        public Guiche()
        {
            cfg = new InteracaoEstacionamentoComCFG();
            cp = new CalculadorDePrecos();
            bcg = new BarCodeGeneratorTM();
            clock = new GeradorDeDataTM();
            yareYare = new InteracaoUsuarioEstacionamento();
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
            Estacionamento vaga = new Estacionamento();
            vaga.ticket = bcg.generateCode();
            vaga.dt_hr_entrada = clock.HoraCustom(dataEmissao);
            vaga.emitido_por = "Guichê";
            vaga.valor_pago = 0.0;
            vaga.Liberado = false;
            if(extravio == true)
            {
                vaga.CodEspecial = "TKEXT";
            }
            else { vaga.CodEspecial = geraCodespecial(); }

            while(cfg.codExiste(vaga.ticket) == true)
            {
                vaga.ticket = bcg.generateCode();
            }
            cfg.ocupaVaga(vaga);
            return vaga.ticket;
            
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
        
        public Boolean liberaTicketPorPagamento(string cod)
        {
          if(cfg.codExiste(cod) == true){
                var ticket = yareYare.getVagaPeloTicket(cod);
                var divida = valorPagar(cod);
                cfg.liberaTicket(ticket);
                cp.alteraPrecoPagar(cod, divida);
                return true;
            }
            return false;
        }

        

    }
}