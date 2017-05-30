namespace EstacionamentoWebApp.Migrations
{
    using EstacionamentoWebApp.BLL;
    using EstacionamentoWebApp.Controllers;
    using PL.Model.POCO;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PL.Model.EstacionamentoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            
                   }

        protected override void Seed(PL.Model.EstacionamentoContext context)
        {


            BarCodeGeneratorTM bcg = new BarCodeGeneratorTM();
            GeradorDeDataTM gd = new GeradorDeDataTM();
            string format = "MM-dd-yyyy HH:mm:ss";


            var CFG = new List<CFG_Estacionamento> {


            new CFG_Estacionamento { codigo_estacionamento = 01, nome = "Neon Genisis Evangelion Parkinglot",  qtd_vagas =  40,
            horaAbertura =  DateTime.ParseExact("01-01-1990 08:00:00", "MM-dd-yyyy HH:mm:ss", new CultureInfo("en-US")),
            horaEncerrameto =   DateTime.ParseExact("01-01-1990 02:00:00", "MM-dd-yyyy HH:mm:ss", new CultureInfo("en-US")),
            valorFixoPernoite = 50.00, valorFixoAcima3Horas = 20.00, valorFixo3Horas = 5.00, valorFixoExtravio = 50.0},
            };

            CFG.ForEach(s => context.CFG_Estacionamentos.AddOrUpdate(e => e.codigo_estacionamento, s));
            context.SaveChanges();


            var user = new List<Usuario> {


            new Usuario { nome = "Victor S.",  funcao =  "Administrador",email = "victor@email.com", senha = "senhaadm" },
            new Usuario { nome = "Joao da Silva",  funcao =  "Guiche", email = "sim@asdoihauhosd", senha = "123" },
            new Usuario { nome = "Maria Pinheiro",  funcao =  "Guiche", email = "naein@email.com", senha = "321" },
            };
            user.ForEach(s => context.Users.AddOrUpdate(f => f.UsuarioID, s));
            context.SaveChanges();

            var Ests = new List<Estacionamento> {
                //new CultureInfo("en-US"))
               
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")),  emitido_por = "Cancela", valor_pago = 0.0, liberacao_especial = "Nenhuma" },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("05-29-2017 10:30:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact(gd.now(), format ,new CultureInfo("en-US")) , emitido_por = "Cancela" },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact(gd.now(),format,new CultureInfo("en-US")),  emitido_por = "Guichê"},
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada =  DateTime.ParseExact(gd.now(),format, new CultureInfo("en-US")), emitido_por = "Guichê"},
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada =  DateTime.ParseExact("05-29-2017 10:30:00", format ,new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact(gd.now(), format ,new CultureInfo("en-US")) , emitido_por = "Cancela" },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada =  DateTime.ParseExact(gd.now(),format, new CultureInfo("en-US")), emitido_por = "Guichê" },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada =  DateTime.ParseExact(gd.now(),format, new CultureInfo("en-US")), emitido_por = "Guichê" },

            };

            Ests.ForEach(s => context.Estacionamentos.AddOrUpdate(f => f.ticket, s));
            context.SaveChanges();

        } }


    }


