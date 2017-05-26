using PL.Model.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.DAO
{
   public  interface ICfgDAO : IDisposable
    {
        IEnumerable<CFG_Estacionamento> getCFG();
        CFG_Estacionamento GetConfiguracao();
        void Update(CFG_Estacionamento est);
    }
}
