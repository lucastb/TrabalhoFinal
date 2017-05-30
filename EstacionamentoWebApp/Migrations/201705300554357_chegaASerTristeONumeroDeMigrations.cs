namespace EstacionamentoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chegaASerTristeONumeroDeMigrations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CFG_Estacionamento", "valorFixoExtravio", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CFG_Estacionamento", "valorFixoExtravio");
        }
    }
}
