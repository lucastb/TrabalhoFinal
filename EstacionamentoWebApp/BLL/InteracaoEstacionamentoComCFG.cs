using PL.DAO;
using PL.Model.POCO;
using System;
using EstacionamentoWebApp.BLL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EstacionamentoWebApp.Controllers;

namespace EstacionamentoWebApp.BLL
{
    public class InteracaoEstacionamentoComCFG
    {
        EstacionamentoDAOImpl estDAO;
        CfgDAOImpl cfgDAO;
        BarCodeGeneratorTM geradorCod;

        public InteracaoEstacionamentoComCFG()
        {
            estDAO = new EstacionamentoDAOImpl();
            cfgDAO = new CfgDAOImpl();
            geradorCod = new BarCodeGeneratorTM();
        }

        public Boolean ocupaVaga(Estacionamento est)
        {
            if (getVagasDisponiveis() <= 0)
            {
                return false;
            }
            //se for igual gera outro codigo 
                if(estDAO.Add(est) == false)
            {
                var novoCod = geradorCod.generateCode();
                est.ticket = novoCod;
                ocupaVaga(est);
                return true;
            }
            estDAO.Add(est);
            return true;

        }
        public void liberaTicket(Estacionamento vaga)
        {
            estDAO.liberaTicket(vaga);
        }

        public void nLiberaTicket(Estacionamento vaga)
        {
            estDAO.nLiberaTicket(vaga);
        }

        public Boolean codRepetido(string cod)
        {
            if(estDAO.Repetido(cod) == true)
            {
                return true;
            }
            return false;
        }

        public int getVagasDisponiveis()
        {
            int nVagasLimite = cfgDAO.GetConfiguracao().qtd_vagas;

            var vagas = estDAO.getEstacionamentos();
            int vagasOcupadas = 0;

            foreach (Estacionamento vaga in vagas)
            {
                if(vaga.dt_hr_saida == null ) 
                {                                                       
                    vagasOcupadas++;
                }

            }
            vagasOcupadas = nVagasLimite - vagasOcupadas;
            return vagasOcupadas;
        }
        
        public Boolean codExiste(string cod)
        {
           var vagas = estDAO.getEstacionamentos();
            foreach(Estacionamento est in vagas)
            {
                if(est.ticket.Equals(cod) == true)
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean aberto()
        {
            if(DateTime.Now.Hour < 2 && DateTime.Now.Hour >= 8)
            {
                return true;
            }
            return false;
        }
    }
}