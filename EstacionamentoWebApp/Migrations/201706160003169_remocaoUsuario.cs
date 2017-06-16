namespace EstacionamentoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remocaoUsuario : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Usuarios");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        funcao = c.String(),
                        email = c.String(),
                        senha = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
        }
    }
}
