namespace Concesoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Factura", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Factura", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Factura", "UsuarioId");
            RenameColumn(table: "dbo.Factura", name: "ApplicationUser_Id", newName: "UsuarioId");
            AlterColumn("dbo.Factura", "UsuarioId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Factura", "UsuarioId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Factura", "UsuarioId");
            AddForeignKey("dbo.Factura", "UsuarioId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Factura", "UsuarioId", "dbo.AspNetUsers");
            DropIndex("dbo.Factura", new[] { "UsuarioId" });
            AlterColumn("dbo.Factura", "UsuarioId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Factura", "UsuarioId", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Factura", name: "UsuarioId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Factura", "UsuarioId", c => c.String(nullable: false));
            CreateIndex("dbo.Factura", "ApplicationUser_Id");
            AddForeignKey("dbo.Factura", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
