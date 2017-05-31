using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL.Model.POCO;

namespace PL.DAO
{
    public interface IMotivosLiberacaoDAO : IDisposable
    {
        IEnumerable<MotivosLiberacao> getMotivos();
        MotivosLiberacao getMotivoById(int id);
        void Add(MotivosLiberacao mot);
        void Delete(int cod);
        void Update(MotivosLiberacao mot);
        void alteraStatusAtivado(MotivosLiberacao mot);
    }
}
