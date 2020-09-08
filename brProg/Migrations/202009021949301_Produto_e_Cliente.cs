namespace brProg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Produto_e_Cliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NomeCliente = c.String(),
                        Telefone = c.String(),
                        Cpf = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NomeProduto = c.String(),
                        Valor = c.String(),
                        Imagem = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Produtoes");
            DropTable("dbo.Clientes");
        }
    }
}
