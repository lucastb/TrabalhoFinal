using PL.Model.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.DAO
{
    public interface IEstacionamento : IDisposable
    {
        IEnumerable<Estacionamento> getEstacionamentos();
        Estacionamento getEstacionamentoByID(int EstacionamentoID);
        void Add(Estacionamento est);
        void Delete(int EstacionamentoID);
        void Update(Estacionamento est);

    }
}
