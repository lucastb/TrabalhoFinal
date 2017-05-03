namespace TrabalhoFinal.Migrations
{
    using PL.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PL.Models.VagaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PL.Models.VagaContext context)
        {
            var vagas = new List<Vaga>
            {
                new Vaga { codigo = "854123658985", HoraDeEntrada = DateTime.Parse("5/1/2017 07:00:00 AM",new CultureInfo("en-US")) },
                new Vaga { codigo = "986574256987", HoraDeEntrada = DateTime.Parse("5/1/2017 07:20:00 AM",new CultureInfo("en-US")) },
               // new Vaga { codigo = "Não Encontrado", HoraDeEntrada = DateTime.Parse("5/1/2017 07:00:00 AM",new CultureInfo("en-US")) },

             };
            vagas.ForEach(s => context.Vagas.AddOrUpdate(g => g.codigo, s));
            context.SaveChanges();
        }
    }
}
