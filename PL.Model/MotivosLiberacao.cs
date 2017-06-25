using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Model.POCO
{
    public class MotivosLiberacao
    {
        public int MotivosLiberacaoId { get; set; }
        public string motivo { get; set; }
        public Boolean ativado { get; set; }
        
    }
}
