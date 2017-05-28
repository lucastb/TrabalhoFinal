using PL.DAO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace EstacionamentoWebApp.BLL
{
    public class CalculadorDePrecos
    {
        EstacionamentoDAOImpl estDAO;
        Controllers.GeradorDeDataTM clock;

        public CalculadorDePrecos()
        {
            estDAO = new EstacionamentoDAOImpl();
            clock = new Controllers.GeradorDeDataTM();
        }

        public Boolean checaCortesia(string cod)
        {
            var vaga = estDAO.GetEstacionamentoByID(cod);
            if (checaTempo(cod) == 0)
            {
                if (clock.diferencaMinutos(DateTime.Now, vaga.dt_hr_entrada) <= 15)
                {
                    return true;
                }
            }
            return false;
        }


        public int checaTempo(string cod)
        {
            var dataVaga = estDAO.GetEstacionamentoByID(cod).dt_hr_entrada.Date;
            int ponderacao;
            var resultado = DateTime.Compare(DateTime.Now.Date, dataVaga);

            if (resultado < 0)
            {
                ponderacao = -1;
                return ponderacao;
            }

            if (resultado > 0)
            {
                ponderacao = 1;
                return ponderacao;
            }

            if (resultado == 0)
            {
                ponderacao = 0;
                return ponderacao;
            }

            return 2;

        }

        //FAZER
        public double calculaPreco(string cod)
        {
            // if(checaTempo)
            return 0;
        }



    }
}