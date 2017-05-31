using PL.Model.POCO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Model
{
  public   class EstacionamentoContext : DbContext
    {
        public EstacionamentoContext() : base("EstacionamentoContext")
 {
        }

        public DbSet<Estacionamento> Estacionamentos { get; set; }
        public DbSet<Usuario> Users { get; set; }
        public DbSet<CFG_Estacionamento> CFG_Estacionamentos { get; set; }
        public DbSet<MotivosLiberacao> motivos { get; set; }
    }
}
