using PL.DAO;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            IVagaDAOImpl v = new IVagaDAOImpl();
            Console.WriteLine(v.getVagasOcupadas());
            Console.WriteLine(v.getNumVagasDisp());
            Console.WriteLine(v.bodeEspiatorio());
            Console.WriteLine(v.getVagas());
            Console.WriteLine(v.GetVagaByID(878787).codigo);

            //Vaga js = new Vaga
            //{

            //    codigo = "Não Encontrado",
            //    HoraDeEntrada = DateTime.Parse("1/1/1990 00:00:00 AM", new CultureInfo("en-US"))

            //};


            //v.Add(js);

            //v.Delete(v.getIDPeloCod("2854684684"));

            Console.ReadKey();
        }
    }
}
