using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL.Model.POCO;
using PL.Model;

namespace PL.DAO
{
    public class EstacionamentoDAOImpl : IEstacionamentoDAO
    {
        EstacionamentoContext context;

        public EstacionamentoDAOImpl()
        {
            context = new EstacionamentoContext();
        }
        public void Add(Estacionamento est)
        {
            context.Estacionamentos.Add(est);
            context.SaveChanges();

        }


        public Boolean validaTicket(string cod)
        {
            if (GetEstacionamentoByID(cod).ticket.Equals("Not Found"))
            {
                return false;
            }
            return true;
        }

        public void Delete(int cod)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Estacionamento GetEstacionamentoByID(string cod)
        {
            Estacionamento Chiketto;

            var vagas = getEstacionamentos();
            foreach (Estacionamento ests in vagas)
            {
                if (ests.ticket == cod)
                {

                    Chiketto = ests;

                    return Chiketto;
                }

            }
            Chiketto = new Estacionamento();
            Chiketto.ticket = "Not Found";
            return Chiketto;
        }

        public IEnumerable<Estacionamento> getEstacionamentos()
        {
            var vagas = context.Estacionamentos.ToList();
            return vagas;
        }

        public void Update(Estacionamento est)
        {
            throw new NotImplementedException();
        }
    }
}
