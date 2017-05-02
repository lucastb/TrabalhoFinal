namespace TrabalhoFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agoravai : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vagas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        codigo = c.String(),
                        HoraDeEntrada = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vagas");
        }
    }
}
