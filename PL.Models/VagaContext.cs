using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.Models
{
  public class VagaContext : DbContext
        {
            public VagaContext() : base("VagaContext")
            {
            }
            public DbSet<Vaga> Vagas { get; set; }
            
        }
    
}
