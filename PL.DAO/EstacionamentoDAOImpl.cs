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


        public Boolean Add(Estacionamento est)
        {
            var vagas = getEstacionamentos();
            foreach(Estacionamento estDaLista in vagas)
            {
                if (estDaLista.ticket.Equals(est.ticket))
                {
                    return false;
                }
            }
            context.Estacionamentos.Add(est);
            context.SaveChanges();
            return true;

        }


        public Boolean Repetido(string cod)
        {
            var vagas = getEstacionamentos();
            foreach (Estacionamento estDaLista in vagas)
            {
                if (estDaLista.ticket.Equals(cod))
                {
                    return true;
                }
            }
            return false;
        }

        public void Update(Estacionamento est)
        {
           var vagaOriginal = context.Estacionamentos.Find(est.EstacionamentoId);
            vagaOriginal = est;
            context.SaveChanges();
        }

        public void mudarHoraDeSaida(Estacionamento vaga, DateTime saida)
        {
            var vagaOriginal = context.Estacionamentos.Find(vaga.EstacionamentoId);
            if(vagaOriginal != null)
            {
                vagaOriginal.dt_hr_saida = saida;
                context.SaveChanges();
            }
        }

        public void liberacaoEspecial(Estacionamento vaga, string motivo)
        {
            var vagaOriginal = context.Estacionamentos.Find(vaga.EstacionamentoId);
            if (vagaOriginal != null)
            {
                vagaOriginal.liberacao_especial = motivo;
                context.SaveChanges();
            }
        }

        public void emitidoPor(Estacionamento vaga, string emissor)
        {
            var vagaOriginal = context.Estacionamentos.Find(vaga.EstacionamentoId);
            if (vagaOriginal != null)
            {
                vagaOriginal.emitido_por = emissor;
                context.SaveChanges();
            }
        }

        public void modificarValorAPagar(Estacionamento vaga, double valor)
        {
            var vagaOriginal = context.Estacionamentos.Find(vaga.EstacionamentoId);
            if (vagaOriginal != null)
            {
                vagaOriginal.valor_pago = valor;
                context.SaveChanges();
            }
        }

        public void liberaTicket(Estacionamento vaga)
        {
            var vagaOriginal = context.Estacionamentos.Find(vaga.EstacionamentoId);
            if (vagaOriginal != null)
            {
                vagaOriginal.Liberado = true;
                context.SaveChanges();
            }
        }

        public void nLiberaTicket(Estacionamento vaga)
        {
            var vagaOriginal = context.Estacionamentos.Find(vaga.EstacionamentoId);
            if (vagaOriginal != null)
            {
                vagaOriginal.Liberado = false;
                context.SaveChanges();
            }
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

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        
    }
}
