using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.DAO
{
    
        public interface IVagaDAO : IDisposable
        {
            IEnumerable<Vaga> getVagas();
            Vaga GetVagaByID(int vagaId);
            void Add(Vaga vaga);
            void Delete(int vagaId);
            void Update(Vaga vaga);

        
    }
}
