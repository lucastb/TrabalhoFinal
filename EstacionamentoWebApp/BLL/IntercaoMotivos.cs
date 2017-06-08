using PL.DAO;
using PL.Model.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstacionamentoWebApp.BLL
{
    public class IntercaoMotivos
    {
        MotivoLiberacaoDAOImpl ml;

        public IntercaoMotivos()
        {
            ml = new MotivoLiberacaoDAOImpl();
        }

        public string motivo()
        {
            return ml.motivo();
        }

        public Boolean temAtivado()
        {
            return ml.temAtivado();
        }

        public IEnumerable<MotivosLiberacao> getMotivos()
        {
            return ml.getMotivos();
        }

        public MotivosLiberacao getMotById(int id)
        {
            return ml.getMotivoById(id);
        }

        public void ativa(MotivosLiberacao mot)
        {
            ml.alteraStatusAtivado(mot);
        }

        public void desativa(MotivosLiberacao mot)
        {
            ml.alteraStatusDesativo(mot);
        }

        public void desativaTodos()
        {
            var motivos = getMotivos();
            foreach(MotivosLiberacao mot in motivos)
            {
                ml.alteraStatusDesativo(mot);
            }
        }
    }
}