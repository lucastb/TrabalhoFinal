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
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada =  DateTime.ParseExact("05-29-2017 10:30:00", format ,new CultureInfo("en-US")),  dt_hr_saida =  DateTime.ParseExact(gd.now(), format ,new CultureInfo("en-US")) , emitido_por = "Cancela", Liberado = true },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada =  DateTime.ParseExact("06-11-2017 10:30:00", format ,new CultureInfo("en-US")), emitido_por = "Guichê", Liberado = false, CodEspecial = "TKTEXT" },
            new Estacionamento { ticket = bcg.generateCode(), dt_hr_entrada =  DateTime.ParseExact("06-12-2017 10:30:00", format ,new CultureInfo("en-US")), emitido_por = "Guichê", Liberado = false, CodEspecial = "TKTEXT" },

            };

            Ests.ForEach(s => context.Estacionamentos.AddOrUpdate(f => f.EstacionamentoId, s));
            context.SaveChanges();


            var user = new List<Usuario> {


            new Usuario { nome = "Victor S.",  funcao =  "Administrador",email = "victor@email.com", senha = "senhaadm" },
            new Usuario { nome = "Joao da Silva",  funcao =  "Guiche", email = "sim@asdoihauhosd", senha = "123" },
            new Usuario { nome = "Maria Pinheiro",  funcao =  "Guiche", email = "naein@email.com", senha = "321" },
            };
            user.ForEach(s => context.Users.AddOrUpdate(f => f.UsuarioID, s));
            context.SaveChanges();

        }

    }


    }


