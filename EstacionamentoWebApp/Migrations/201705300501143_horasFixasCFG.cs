namespace EstacionamentoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class horasFixasCFG : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CFG_Estacionamento", "valorFixoPernoite", c => c.Double(nullable: false));
            AddColumn("dbo.CFG_Estacionamento", "valorFixo3Horas", c => c.Double(nullable: false));
            AddColumn("dbo.CFG_Estacionamento", "valorFixoAcima3Horas", c => c.Double(nullable: false));
            DropColumn("dbo.CFG_Estacionamento", "valorFixo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CFG_Estacionamento", "valorFixo", c => c.Double(nullable: false));
            DropColumn("dbo.CFG_Estacionamento", "valorFixoAcima3Horas");
            DropColumn("dbo.CFG_Estacionamento", "valorFixo3Horas");
            DropColumn("dbo.CFG_Estacionamento", "valorFixoPernoite");
        }
    }
}
