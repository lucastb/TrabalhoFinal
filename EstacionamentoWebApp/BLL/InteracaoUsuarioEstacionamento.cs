using PL.DAO;
using PL.Model.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoWebApp.BLL
{
    public class InteracaoUsuarioEstacionamento
    {
        UsuarioDAOImpl userDAO;
        EstacionamentoDAOImpl  estDAO;
        public InteracaoUsuarioEstacionamento()
        {
            userDAO = new UsuarioDAOImpl();
            estDAO = new EstacionamentoDAOImpl();
        }

        public Estacionamento getVagaPeloTicket(string cod)
        {
            var vaga = estDAO.GetEstacionamentoByID(cod);
            return vaga;
        }

        public Boolean liberacaoEspecial(string Ticket, string motivo )
        {
            var vaga = estDAO.GetEstacionamentoByID(Ticket);
            estDAO.liberacaoEspecial(getVagaPeloTicket(Ticket), motivo);
            return true;
        }

        //fazer
        public Boolean liberarSaida(string cod)  
        {
          var ticketParaValidar = estDAO.GetEstacionamentoByID(cod);
            
            return true;
        }

    }
}