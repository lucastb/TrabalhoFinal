namespace EstacionamentoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CFG_Estacionamento", "horaAbertura", c => c.DateTime(nullable: false));
            AddColumn("dbo.CFG_Estacionamento", "horaEncerrameto", c => c.DateTime(nullable: false));
            AddColumn("dbo.Usuarios", "email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "email");
            DropColumn("dbo.CFG_Estacionamento", "horaEncerrameto");
            DropColumn("dbo.CFG_Estacionamento", "horaAbertura");
        }
    }
}
