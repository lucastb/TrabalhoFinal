using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL.Models;
using System.Globalization;

namespace PL.DAO
{
    public class IVagaDAOImpl : IVagaDAO
    {
        Estacionamento est = new Estacionamento();
        VagaContext contexto;

        public IVagaDAOImpl()
        {
            contexto = new VagaContext();
            est.setVaga(getVagas().Count());
            if(failSafe() == false)
            {
                Vaga bode = new Vaga{codigo = "Não Encontrado",  HoraDeEntrada = DateTime.Parse("1/1/1990 00:00:00 AM", new CultureInfo("en-US"))
};
                Add(bode);
            }

        }

        public int getVagasOcupadas()
        {
            var vagas = est.getVagas() - 1;
            if (vagas <= 0)
            {
                return 0;
            }
            else {
                return vagas; }
        }

        public int getNumVagasDisp()
        {
            int disp = 20 - getVagasOcupadas();
            return disp;
        }


        public void Add(Vaga vaga)
        {
            if (getVagasOcupadas() < 20)
            {
                contexto.Vagas.Add(vaga);
                contexto.SaveChanges();
            }
            return;
        }

        public int getIDPeloCod(string cod)
        {
            var lista = getVagas();
            foreach (Vaga a in lista)
            {
                if (a.codigo == cod)
                {
                    return a.ID;
                }
            }
            return bodeEspiatorio().ID;
        }


        public void Delete(int vagaId)
        {
            
            Vaga a = GetVagaByID(vagaId);
            if(a.codigo.Equals("Não Encontrado"))
            {
                return;
            }
            contexto.Vagas.Remove(a);
            contexto.SaveChanges();
        }

        

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Vaga GetVagaByID(int vagaId)
        {
            Vaga v;

            var listaVagas = getVagas();
            foreach (Vaga vag in listaVagas)
            {
                if (vag.ID == vagaId )
                {
                    v = vag;
                    return v;
                }
            }
            //jeito facil de retornar quando id errado...
            v = bodeEspiatorio();

            return v;

        }


        public IEnumerable<Vaga> getVagas()

        {
            
            var listaVagas = contexto.Vagas.ToList();
            //"Não Encontrado"
            
           

            return listaVagas;
            }

       

        public void Update(Vaga Vaga)
        {
            throw new NotImplementedException();
        }

        public Vaga bodeEspiatorio()
        {
            var id  = getIDPeloCod("Não Encontrado");
            Vaga bode = GetVagaByID(id);
            return bode;
        }
    
        public Boolean failSafe()
        {
            
            var lista = getVagas();
            foreach (Vaga a in lista)
            {
                if (a.codigo.Equals("Não Encontrado"))
                {
                    return true;
                }
                
            }
            return false;
        }
    }
}
