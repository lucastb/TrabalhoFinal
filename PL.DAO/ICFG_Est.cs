using PL.Model.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PL.DAO
{
    public interface ICFG_Est : IDisposable
    {
        IEnumerable<CFG_Estacionamento> getCFG_Estacionamentos();
        CFG_Estacionamento GetCFG_EstacionamentoByID(int actorId);
        void Add(CFG_Estacionamento cfg);
        void Delete(int CFG_EstacionamentoID);
        void Update(CFG_Estacionamento CFG);

    }
}
