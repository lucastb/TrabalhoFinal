using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Models
{
    public class Estacionamento
    {
        int vagas;
        int limite;

        public Estacionamento()
        {
            this.vagas = 0;
            this.limite = 20;
        }

        public Boolean ocupaVaga()
        {
            if(vagas < 20)
            {
                vagas++;
                return true;
            }
            return false;
        }

        public void desocupaVaga()
        {
            vagas--;
        }
        
        public void setVaga(int n)
        {
            vagas = n;
        }

        public int getVagas()
        {
            return vagas;
        }
    }
}
