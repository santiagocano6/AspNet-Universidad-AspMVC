namespace Concesoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cotizacion", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Factura", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Cedula", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Nombre", c => c.String());
            AddColumn("dbo.AspNetUsers", "Telefono", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Direccion", c => c.String());
            AddColumn("dbo.AspNetUsers", "Ciudad", c => c.String());
            AddColumn("dbo.AspNetUsers", "Rol", c => c.String());
            CreateIndex("dbo.Cotizacion", "ApplicationUser_Id");
            CreateIndex("dbo.Factura", "ApplicationUser_Id");
            AddForeignKey("dbo.Cotizacion", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Factura", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Factura", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cotizacion", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Factura", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Cotizacion", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "Rol");
            DropColumn("dbo.AspNetUsers", "Ciudad");
            DropColumn("dbo.AspNetUsers", "Direccion");
            DropColumn("dbo.AspNetUsers", "Telefono");
            DropColumn("dbo.AspNetUsers", "Nombre");
            DropColumn("dbo.AspNetUsers", "Cedula");
            DropColumn("dbo.Factura", "ApplicationUser_Id");
            DropColumn("dbo.Cotizacion", "ApplicationUser_Id");
        }
    }
}
