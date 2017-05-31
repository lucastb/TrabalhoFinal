namespace EstacionamentoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class liberadoTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Estacionamentoes", "Liberado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Estacionamentoes", "Liberado");
        }
    }
}
