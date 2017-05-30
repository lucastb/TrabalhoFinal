using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Model.POCO
{
   public  class CFG_Estacionamento
    {
        [Key]
        public int codigo_estacionamento { get; set; }
        
        public string nome { get; set; }
        public int qtd_vagas { get; set; }
        public DateTime horaAbertura { get; set; }
        public DateTime horaEncerrameto { get; set; }
        public double valorFixoPernoite { get; set; }
        public double valorFixo3Horas { get; set; }
        public double valorFixoAcima3Horas { get; set; }
        public double valorFixoExtravio { get; set; }


    }
}
