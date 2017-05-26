using PL.Model.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.DAO
{
    
    public interface IEstacionamentoDAO : IDisposable
    {
        IEnumerable<Estacionamento> getEstacionamentos();
        Estacionamento GetEstacionamentoByID(string cod);
        Boolean Add(Estacionamento est);
        void Delete(int cod);
        void Update(Estacionamento est);
    }
}
