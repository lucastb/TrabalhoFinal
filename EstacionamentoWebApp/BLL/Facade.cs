using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoWebApp.BLL
{
    public class Facade
    {
        InteracaoEstacionamentoComCFG intCfg;
        InteracaoUsuarioEstacionamento intUser;

        public Facade()
        {
            intCfg = new InteracaoEstacionamentoComCFG();
            intUser = new InteracaoUsuarioEstacionamento();
        }

        //1 - Número de vagas disponíveis. Como o estacionamento possui um número máximo de vagas, o sistema
        //deve ser capaz de informar o número atual de vagas livres
        public int nDeVagasDisponiveis()
        {
            return intCfg.getVagasDisponiveis();
        }

        //2 - Consulta do valor a ser pago pelo ticket do estacionamento. Com base no número de identificação, o
        //sistema deve fornecer o valor atual a ser pago para a liberação do ticket de estacionamento.


    }
}