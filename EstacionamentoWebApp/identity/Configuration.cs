namespace EstacionamentoWebApp.identity
{
    using EstacionamentoWebApp.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ConfigurationIdentity : DbMigrationsConfiguration<EstacionamentoWebApp.Models.ApplicationDbContext>
    {
        public ConfigurationIdentity()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"identity";
        }

        protected override void Seed(EstacionamentoWebApp.Models.ApplicationDbContext context)
        {
            var hasher = new PasswordHasher();
            context.Users.AddOrUpdate(
            u => u.UserName,
            new ApplicationUser
            {
                UserName = "aa@psa.br",
                //FullName = "Usuario AA",
                PasswordHash = hasher.HashPassword("senha123"),
                SecurityStamp = Guid.NewGuid().ToString()
            },
            new ApplicationUser
            {
                UserName = "admin@psa.br",
                //FullName = "Administrador",
                PasswordHash = hasher.HashPassword("Pass@word1"),
                SecurityStamp = Guid.NewGuid().ToString()
            });        }
    }
}
