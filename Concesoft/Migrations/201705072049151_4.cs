namespace Concesoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cotizacion", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Factura", "UsuarioId", "dbo.Usuario");
            DropIndex("dbo.Cotizacion", new[] { "UsuarioId" });
            DropIndex("dbo.Factura", new[] { "UsuarioId" });
            AddColumn("dbo.Cotizacion", "UsuarioModels_UsuarioId", c => c.Int());
            AddColumn("dbo.Factura", "UsuarioModels_UsuarioId", c => c.Int());
            AlterColumn("dbo.Cotizacion", "UsuarioId", c => c.String(nullable: false));
            AlterColumn("dbo.Factura", "UsuarioId", c => c.String(nullable: false));
            CreateIndex("dbo.Cotizacion", "UsuarioModels_UsuarioId");
            CreateIndex("dbo.Factura", "UsuarioModels_UsuarioId");
            AddForeignKey("dbo.Cotizacion", "UsuarioModels_UsuarioId", "dbo.Usuario", "UsuarioId");
            AddForeignKey("dbo.Factura", "UsuarioModels_UsuarioId", "dbo.Usuario", "UsuarioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Factura", "UsuarioModels_UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Cotizacion", "UsuarioModels_UsuarioId", "dbo.Usuario");
            DropIndex("dbo.Factura", new[] { "UsuarioModels_UsuarioId" });
            DropIndex("dbo.Cotizacion", new[] { "UsuarioModels_UsuarioId" });
            AlterColumn("dbo.Factura", "UsuarioId", c => c.Int(nullable: false));
            AlterColumn("dbo.Cotizacion", "UsuarioId", c => c.Int(nullable: false));
            DropColumn("dbo.Factura", "UsuarioModels_UsuarioId");
            DropColumn("dbo.Cotizacion", "UsuarioModels_UsuarioId");
            CreateIndex("dbo.Factura", "UsuarioId");
            CreateIndex("dbo.Cotizacion", "UsuarioId");
            AddForeignKey("dbo.Factura", "UsuarioId", "dbo.Usuario", "UsuarioId", cascadeDelete: true);
            AddForeignKey("dbo.Cotizacion", "UsuarioId", "dbo.Usuario", "UsuarioId", cascadeDelete: true);
        }
    }
}
