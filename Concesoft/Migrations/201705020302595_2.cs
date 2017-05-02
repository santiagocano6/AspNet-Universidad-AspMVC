namespace Concesoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false),
                        Nombre = c.String(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Direccion = c.String(nullable: false),
                        Ciudad = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            AddColumn("dbo.Cotizacion", "ClienteId", c => c.Int(nullable: false));
            AddColumn("dbo.Factura", "ClienteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cotizacion", "ClienteId");
            CreateIndex("dbo.Factura", "ClienteId");
            AddForeignKey("dbo.Cotizacion", "ClienteId", "dbo.Cliente", "ClienteId", cascadeDelete: true);
            AddForeignKey("dbo.Factura", "ClienteId", "dbo.Cliente", "ClienteId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Factura", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Cotizacion", "ClienteId", "dbo.Cliente");
            DropIndex("dbo.Factura", new[] { "ClienteId" });
            DropIndex("dbo.Cotizacion", new[] { "ClienteId" });
            DropColumn("dbo.Factura", "ClienteId");
            DropColumn("dbo.Cotizacion", "ClienteId");
            DropTable("dbo.Cliente");
        }
    }
}
