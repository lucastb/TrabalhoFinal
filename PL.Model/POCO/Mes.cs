using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Model.POCO
{
    public class Mes
    {
        public int nMes { get; set; }
        public string nomeMes { get; set; }

    public IEnumerable<Mes> getMeses()
        {
            var mes = new List<Mes> {
            new Mes {nMes = 1, nomeMes = "Janeiro"},
            new Mes {nMes = 2, nomeMes = "Fevereiro"},
            new Mes {nMes = 3, nomeMes = "Março"},
            new Mes {nMes = 4, nomeMes = "Abril"},
            new Mes {nMes = 5, nomeMes = "Maio"},
            new Mes {nMes = 6, nomeMes = "Junho"},
            new Mes {nMes = 7, nomeMes = "Julho"},
            new Mes {nMes = 8, nomeMes = "Agosto"},
            new Mes {nMes = 9, nomeMes = "Setembro"},
            new Mes {nMes = 10, nomeMes = "Outubro"},
            new Mes {nMes = 11, nomeMes = "Novembro"},
            new Mes {nMes = 12, nomeMes = "Dezembro"},
            };
            return mes;
        }


        public int getnMesPorNomeMes(string nome)
        {
            var listMes = getMeses();
            int aux = 0;
            foreach(Mes m in listMes)
            {
                if (m.nomeMes.Equals(nome))
                {
                     aux = m.nMes;
                }
            }
            return aux;
        }


}
}
