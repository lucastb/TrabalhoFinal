using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Model.POCO
{
  public  class Estacionamento
    {
        public Estacionamento()
        {
            valor_pago = 0.00;
        }

        public string codigo { get; set; }
        public DateTime dt_hr_entrada { get; set; }
        public DateTime dt_hr_saida { get; set; }
        public string emitido_por { get; set; }
        public double valor_pago { get; set; }
        public string liberacao_especial { get; set; }
    }
}
