using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL.Model.POCO;
using PL.Model;

namespace PL.DAO
{
    public class MotivoLiberacaoDAOImpl : IMotivosLiberacaoDAO
    {
        EstacionamentoContext context;

        public MotivoLiberacaoDAOImpl()
        {
            context = new EstacionamentoContext();
        }
        public void Add(MotivosLiberacao mot)
        {
            context.motivos.Add(mot);
            context.SaveChanges();
        }

        public string motivo()
        {
            var motivos = getMotivos();
            foreach(MotivosLiberacao mot in motivos)
            {
                if(mot.ativado == true)
                {
                    return mot.motivo;
                }
            }

            return "erro";
        }

        public void alteraStatusAtivado(MotivosLiberacao mot)
        {
            var motivos = getMotivos();
            var motivoOriginal = context.motivos.Find(mot.MotivosLiberacaoId);
            if (motivoOriginal != null)
            {
                foreach(MotivosLiberacao motiv in motivos)
                {
                    var motivoFalse = context.motivos.Find(motiv.MotivosLiberacaoId);
                    motivoFalse.ativado = false;
                    context.SaveChanges();

                }
                motivoOriginal.ativado = true;
                context.SaveChanges();
            }
        }

        public void alteraStatusDesativo(MotivosLiberacao mot)
        {
            var motivoOriginal = context.motivos.Find(mot.MotivosLiberacaoId);
            if (motivoOriginal != null)
            {
                motivoOriginal.ativado = false;
                context.SaveChanges();
            }
        }

        public void Delete(int cod)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public MotivosLiberacao getMotivoById(int id)
        {
            MotivosLiberacao motivo;
            var motivos = getMotivos();
            foreach(MotivosLiberacao motiv in motivos)
            {
                if (motiv.MotivosLiberacaoId == id)
                {
                    motivo = motiv;
                    return motivo;
                }                
            }
            motivo = new MotivosLiberacao();
            motivo.motivo = "Not Found :o";
            return motivo;
        }


        public IEnumerable<MotivosLiberacao> getMotivos()
        {
            var motivos = context.motivos.ToList();
            return motivos;
        }

        public Boolean temAtivado()
        {
            var motivos = getMotivos();
            foreach(MotivosLiberacao mot in motivos)
            {
                if(mot.ativado == true)
                {
                    return true;
                }                
            }
            return false;
        }

        public void Update(MotivosLiberacao mot)
        {
            throw new NotImplementedException();
        }
    }
}
