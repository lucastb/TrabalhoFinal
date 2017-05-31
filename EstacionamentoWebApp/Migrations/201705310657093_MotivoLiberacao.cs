namespace EstacionamentoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MotivoLiberacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MotivosLiberacaos",
                c => new
                    {
                        MotivosLiberacaoId = c.Int(nullable: false, identity: true),
                        motivo = c.String(),
                        ativado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MotivosLiberacaoId);
            
            AddColumn("dbo.Estacionamentoes", "CodEspecial", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Estacionamentoes", "CodEspecial");
            DropTable("dbo.MotivosLiberacaos");
        }
    }
}
