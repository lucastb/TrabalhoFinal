namespace EstacionamentoWebApp.Migrations
{
    using EstacionamentoWebApp.BLL;
    using EstacionamentoWebApp.Controllers;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
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

            var motivosList = new List<MotivosLiberacao>
            {
                new MotivosLiberacao {motivo = "Promoção", ativado = false  },
                new MotivosLiberacao{motivo = "Emergência", ativado = false},
                new MotivosLiberacao{motivo = "outros", ativado = false},


            };
            motivosList.ForEach(s => context.motivos.AddOrUpdate(e => e.MotivosLiberacaoId, s));
            context.SaveChanges();


            var CFG = new List<CFG_Estacionamento> {


            new CFG_Estacionamento { codigo_estacionamento = 01, nome = "Neon Genisis Evangelion Parkinglot",  qtd_vagas =  40,
            horaAbertura =  DateTime.ParseExact("01-01-1990 08:00:00", "MM-dd-yyyy HH:mm:ss", new CultureInfo("en-US")),
            horaEncerrameto =   DateTime.ParseExact("01-01-1990 02:00:00", "MM-dd-yyyy HH:mm:ss", new CultureInfo("en-US")),
            valorFixoPernoite = 50.00, valorFixoAcima3Horas = 20.00, valorFixo3Horas = 5.00, valorFixoExtravio = 50.0},
            };

            CFG.ForEach(s => context.CFG_Estacionamentos.AddOrUpdate(e => e.codigo_estacionamento, s));
            context.SaveChanges();

            var Ests = new List<Estacionamento> {
                //new CultureInfo("en-US"))
               
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")),  emitido_por = "Cancela", valor_pago = 0.0, Liberado = false },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("05-29-2017 10:30:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact("05-29-2017 12:30:00", format, new CultureInfo("en-US")), valor_pago = 5.00, emitido_por = "Cancela", Liberado = true },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact(gd.now(),format,new CultureInfo("en-US")),  emitido_por = "Cancela", Liberado = false},
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada =  DateTime.ParseExact(gd.now(),format, new CultureInfo("en-US")), emitido_por = "Cancela", Liberado = false},
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada =  DateTime.ParseExact("05-29-2017 10:30:00", format ,new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact(gd.now(), format ,new CultureInfo("en-US")) , valor_pago = 700, emitido_por = "Cancela", Liberado = true },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada =  DateTime.ParseExact("06-11-2017 10:30:00", format ,new CultureInfo("en-US")), emitido_por = "Guichê", Liberado = false, CodEspecial = "TKTEXT" },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada =  DateTime.ParseExact("06-12-2017 10:30:00", format ,new CultureInfo("en-US")), emitido_por = "Guichê", Liberado = false, CodEspecial = "TKTEXT" },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("02-12-2017 10:30:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact("02-12-2017 12:30:00", format, new CultureInfo("en-US")), valor_pago = 5.00, emitido_por = "Cancela", Liberado = true },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("05-29-2017 10:30:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact("05-29-2017 12:30:00", format, new CultureInfo("en-US")), valor_pago = 5.00, emitido_por = "Cancela", Liberado = true },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("03-19-2017 10:30:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact("03-29-2017 12:30:00", format, new CultureInfo("en-US")), valor_pago = 500.00, emitido_por = "Cancela", Liberado = true },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("03-12-2017 08:00:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact("03-12-2017 12:30:00", format, new CultureInfo("en-US")), valor_pago = 20.00, emitido_por = "Cancela", Liberado = true },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("04-19-2017 10:30:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact("04-19-2017 12:30:00", format, new CultureInfo("en-US")), valor_pago = 5.00, emitido_por = "Cancela", Liberado = true },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("04-12-2017 10:30:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact("04-12-2017 12:30:00", format, new CultureInfo("en-US")), valor_pago = 5.00, emitido_por = "Cancela", Liberado = true },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("05-11-2017 10:30:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact("05-11-2017 12:30:00", format, new CultureInfo("en-US")), valor_pago = 5.00, emitido_por = "Cancela", Liberado = true },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("06-08-2017 10:30:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact("06-08-2017 12:30:00", format, new CultureInfo("en-US")), valor_pago = 5.00, emitido_por = "Cancela", Liberado = true },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("01-29-2017 10:30:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact("01-29-2017 12:30:00", format, new CultureInfo("en-US")), valor_pago = 5.00, emitido_por = "Cancela", Liberado = true },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("04-12-2017 10:30:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact("04-12-2017 12:30:00", format, new CultureInfo("en-US")), valor_pago = 5.00, emitido_por = "Cancela", Liberado = true },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("08-20-2017 10:30:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact("08-21-2017 12:30:00", format, new CultureInfo("en-US")), valor_pago = 50.00, emitido_por = "Cancela", Liberado = true },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("03-12-2017 10:30:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact("03-12-2017 12:30:00", format, new CultureInfo("en-US")), valor_pago = 5.00, emitido_por = "Cancela", Liberado = true },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("03-29-2017 10:30:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact("03-31-2017 12:30:00", format, new CultureInfo("en-US")), valor_pago = 100.00, emitido_por = "Cancela", Liberado = true },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("01-29-2017 10:30:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact("01-29-2017 12:30:00", format, new CultureInfo("en-US")), valor_pago = 5.00, emitido_por = "Cancela", Liberado = true },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")),  emitido_por = "Cancela", valor_pago = 0.0, Liberado = false },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")),  emitido_por = "Cancela", valor_pago = 0.0, Liberado = false },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")),  emitido_por = "Cancela", valor_pago = 0.0, Liberado = false },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")),  emitido_por = "Cancela", valor_pago = 0.0, Liberado = false },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")),  emitido_por = "Cancela", valor_pago = 0.0, Liberado = false },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")),  emitido_por = "Cancela", valor_pago = 0.0, Liberado = false },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")),  emitido_por = "Cancela", valor_pago = 0.0, Liberado = false },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")), dt_hr_saida = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")), emitido_por = "Cancela", valor_pago = 0.0, Liberado = true, liberacao_especial = "Outro" },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("03-29-2017 10:30:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact("03-31-2017 12:30:00", format, new CultureInfo("en-US")), emitido_por = "Guiche", valor_pago = 0.0, Liberado = true, liberacao_especial = "Promoção", CodEspecial = "TKTEXT" },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")), dt_hr_saida = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")), emitido_por = "Cancela", valor_pago = 0.0, Liberado = true, liberacao_especial = "Cortesia"},
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")), dt_hr_saida = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")), emitido_por = "Guiche", valor_pago = 0.0, Liberado = true, liberacao_especial = "Promoção", CodEspecial = "TKTEXT" },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")), dt_hr_saida = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")), emitido_por = "Cancela", valor_pago = 0.0, Liberado = true, liberacao_especial = "Cortesia"},
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact("01-29-2017 10:30:00", format, new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact("01-29-2017 12:30:00", format , new CultureInfo("en-US")), emitido_por = "Guiche", valor_pago = 0.0, Liberado = true, liberacao_especial = "Emergência", CodEspecial = "AECDASD" },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")), dt_hr_saida = DateTime.ParseExact(gd.now(), format , new CultureInfo("en-US")), emitido_por = "Cancela", valor_pago = 0.0, Liberado = true, liberacao_especial = "Cortesia" },

            };

            Ests.ForEach(s => context.Estacionamentos.AddOrUpdate(f => f.EstacionamentoId, s));
            context.SaveChanges();

        }

    }


    }


