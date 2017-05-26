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
        }

        public Boolean ocupaVaga(Estacionamento est)
        {
            if (getVagasDisponiveis() <= 0)
            {
                return false;
            }

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


        public int getVagasDisponiveis()
        {
            int nVagasLimite = cfgDAO.GetConfiguracao().qtd_vagas;

            var vagas = estDAO.getEstacionamentos();
            int vagasOcupadas = 0;

            foreach (Estacionamento vaga in vagas)
            {
                if(vaga.dt_hr_saida == null)
                {
                    vagasOcupadas++;
                }

            }
            vagasOcupadas = nVagasLimite - vagasOcupadas;
            return vagasOcupadas;
        }
        
    }
}