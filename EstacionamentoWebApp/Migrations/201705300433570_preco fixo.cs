namespace EstacionamentoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class precofixo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CFG_Estacionamento", "valorFixo", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CFG_Estacionamento", "valorFixo");
        }
    }
}
