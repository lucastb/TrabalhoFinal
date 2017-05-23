namespace EstacionamentoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BancoFuncionando100PorCento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CFG_Estacionamento",
                c => new
                    {
                        codigo_estacionamento = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        qtd_vagas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.codigo_estacionamento);
            
            CreateTable(
                "dbo.Estacionamentoes",
                c => new
                    {
                        EstacionamentoId = c.Int(nullable: false, identity: true),
                        ticket = c.String(),
                        dt_hr_entrada = c.DateTime(nullable: false),
                        dt_hr_saida = c.DateTime(),
                        emitido_por = c.String(),
                        valor_pago = c.Double(nullable: false),
                        liberacao_especial = c.String(),
                    })
                .PrimaryKey(t => t.EstacionamentoId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        funcao = c.String(),
                        senha = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuarios");
            DropTable("dbo.Estacionamentoes");
            DropTable("dbo.CFG_Estacionamento");
        }
    }
}
