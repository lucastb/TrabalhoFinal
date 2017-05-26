using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL.Model.POCO;
using PL.Model;

namespace PL.DAO
{
    public class CfgDAOImpl : ICfgDAO
    {
        EstacionamentoContext context;

        public CfgDAOImpl()
        {
            context = new EstacionamentoContext();
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CFG_Estacionamento> getCFG()
        {
            var cfg = context.CFG_Estacionamentos.ToList();
            return cfg;
        }

       
        public CFG_Estacionamento GetConfiguracao()
        {
            CFG_Estacionamento cfg;

            var cfgUnico = getCFG();
            foreach (CFG_Estacionamento aux in cfgUnico)
            {
                if (aux.codigo_estacionamento == 1)
                {
                    cfg = aux;
                    return cfg;
                }

            }
             return cfgUnico.First();
        }

        public void Update(CFG_Estacionamento est)
        {
            throw new NotImplementedException();
        }

        //public Boolean aumentaNumeroDeVagasEm(int qnt)
        //{
            
        //}
    }
}
