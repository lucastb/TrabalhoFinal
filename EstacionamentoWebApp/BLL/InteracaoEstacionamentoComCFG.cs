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
        GeradorDeDataTM clock;

        public InteracaoEstacionamentoComCFG()
        {
            estDAO = new EstacionamentoDAOImpl();
            cfgDAO = new CfgDAOImpl();
            geradorCod = new BarCodeGeneratorTM();
            clock = new GeradorDeDataTM();
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


        //Contar o número de carros que sairam, pelo numero de tickets extraviados q sairam
        public int getExtraviadosQueSairam()
        {
            var vagas = estDAO.getEstacionamentos();
            int nVagas = 0;
            foreach (Estacionamento vaga in vagas)
            {
                if(vaga.CodEspecial != null && vaga.dt_hr_saida != null)
                {
                    nVagas++;
                }
            }
            return nVagas;
        }

        public int getVagasDisponiveis()
        {
            int nVagasLimite = cfgDAO.GetConfiguracao().qtd_vagas;

            var vagas = estDAO.getEstacionamentos();
            int vagasOcupadas = 0;

            foreach (Estacionamento vaga in vagas)
            {
                if (vaga.dt_hr_saida == null & vaga.CodEspecial == null)
                {
                    vagasOcupadas++;
                }

            }
            //pega o numero de tickets extraviados q sairam e adiciona no valor total de vagas, pois 
            //existem tickets "fantasmas", que ficaram para tras e nunca vão sair, pois o "dono"
            //pegou um extraviado e saiu com ele.
            var vagasDisponiveis =  nVagasLimite - vagasOcupadas + getExtraviadosQueSairam();
            return vagasDisponiveis;
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
            if (DateTime.Now.Hour != 2 && DateTime.Now.Hour != 3 && DateTime.Now.Hour != 4 && DateTime.Now.Hour != 5 && DateTime.Now.Hour != 6 && DateTime.Now.Hour != 7)
            {
                return true;
               
            }
            return false;
        }

        public IEnumerable<Estacionamento> getListaDeEstacionamentos()
        {
            return estDAO.getEstacionamentos();
        }

#region parte administrativa
        //O sistema deve possuir também um módulo gerencial que permita obter as seguintes informações relativas ao uso
        //do estacionamento:

        public IEnumerable<Estacionamento> getEstacionamentosQueTemSaida()
        {
            List<Estacionamento> est = new List<Estacionamento>();
            var aux = getListaDeEstacionamentos();
            foreach(Estacionamento e in aux)
            {
                if(e.dt_hr_saida != null)
                {
                    est.Add(e);
                }
            }
            return est;
        }

        public int getNTotalDeTicketsPagos()
        {
            int valor = 0;
            var list = getListaDeEstacionamentos();
            foreach(Estacionamento est in list)
            {
                if(est.valor_pago > 0)
                {
                    valor++;
                }
            }
            return valor;
        }

        public int getNTicketPagosMes(int mes)
        {
            int qntd = 0;
            var list = getListaDeEstacionamentos();
            foreach(Estacionamento est in list)
            {
                if(clock.getMes(est.dt_hr_saida) == mes)
                {
                    qntd++;
                }
            }
            return qntd;
        }

#endregion
    }
}