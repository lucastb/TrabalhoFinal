using EstacionamentoWebApp.Controllers;
using PL.DAO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EstacionamentoWebApp.BLL
{
    public class Validador
    {
        CalculadorDePrecos calc;
        EstacionamentoDAOImpl est;
        GeradorDeDataTM datador;


        public Validador()
        {
            calc = new CalculadorDePrecos();
            est = new EstacionamentoDAOImpl();
            datador = new GeradorDeDataTM();
        }

        public void liberaSaida(string cod)
        {
            if (calc.checaCortesia(cod) == false)
            {
                //FAZER ALTOS CODIGO

            }
            else
            {
                var ticket = est.GetEstacionamentoByID(cod);
                double valor = 0.0;
                string motivo = "Cortesia";
                est.modificarValorAPagar(ticket, valor);
                est.liberacaoEspecial(ticket, motivo);
                est.mudarHoraDeSaida(ticket, DateTime.Parse(datador.now(), new CultureInfo("en-US")));
            }
        }
    }
}