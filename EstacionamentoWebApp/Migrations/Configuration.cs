namespace EstacionamentoWebApp.Migrations
{
    using PL.Model.POCO;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PL.Model.EstacionamentoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PL.Model.EstacionamentoContext context)
        {
            var CFG = new List<CFG_Estacionamento> {


            new CFG_Estacionamento { codigo_estacionamento = 01, nome = "Neon Genisis Evangelion Parkinglot",  qtd_vagas =  40 },
            };

            CFG.ForEach(s => context.CFG_Estacionamentos.AddOrUpdate(e => e.codigo_estacionamento, s));
            context.SaveChanges();

            var Ests = new List<Estacionamento> {


            new Estacionamento { ticket = "PlaceHolder1", dt_hr_entrada = "George Lucas",  dt_hr_saida =  , emitido_por = "Cancela", valor_pago = 0.0, liberacao_especial = "Nenhuma" },
            new Estacionamento { ticket = "PlaceHolder2", dt_hr_entrada = "Robert Zemeckis",  dt_hr_saida =  , emitido_por = "Cancela" },
            new Estacionamento { ticket = "PlaceHolder3", dt_hr_entrada = "Steven Spielberg",  dt_hr_saida =   , emitido_por = "Guichê"},
            new Estacionamento { ticket = "PlaceHolder4", dt_hr_entrada = "Irvin Kershner", dt_hr_saida =   , emitido_por = "Guichê"},
            new Estacionamento { ticket = "PlaceHolder5", dt_hr_entrada = "Richard Marquand",  dt_hr_saida =  , emitido_por = "Cancela" },
            new Estacionamento { ticket = "PlaceHolder6", dt_hr_entrada = "Martin Campbell",  dt_hr_saida =   , emitido_por = "Guichê" },
            };

            Ests.ForEach(s => context.Estacionamentos.AddOrUpdate(f => f.ticket, s));
            context.SaveChanges();


        } }


    }
}
}
