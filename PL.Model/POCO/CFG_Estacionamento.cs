using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Model.POCO
{
   public  class CFG_Estacionamento
    {
        public int codigo_estacionamento { get; set; }
        public string nome { get; set; }
        public int qtd_vagas { get; set; }
    }
}
