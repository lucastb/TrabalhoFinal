using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Model.POCO
{
   public class Usuario
    {
        [Key]
        public int ID_user { get; set; }
        
        public string nome { get; set; }
        public string funcao { get; set; }
        public string senha { get; set; }

    }
}
