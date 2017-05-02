namespace Concesoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cotizacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        ValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.DetalleCotizacion",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CotizacionId = c.Int(nullable: false),
                        VehiculoId = c.Int(nullable: false),
                        RepuestoAccesorioId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        ValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CotizacionModels_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cotizacion", t => t.CotizacionModels_Id)
                .ForeignKey("dbo.RepuestoAccesorio", t => t.RepuestoAccesorioId, cascadeDelete: true)
                .ForeignKey("dbo.Vehiculo", t => t.VehiculoId, cascadeDelete: true)
                .Index(t => t.VehiculoId)
                .Index(t => t.RepuestoAccesorioId)
                .Index(t => t.CotizacionModels_Id);
            
            CreateTable(
                "dbo.RepuestoAccesorio",
                c => new
                    {
                        RepuestoAccesorioId = c.Int(nullable: false, identity: true),
                        NombreArticulo = c.String(nullable: false),
                        CantidadDisponible = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RepuestoAccesorioId);
            
            CreateTable(
                "dbo.DetalleFactura",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FacturaId = c.Int(nullable: false),
                        VehiculoId = c.Int(nullable: false),
                        RepuestoAccesorioId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        ValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FacturaModels_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Factura", t => t.FacturaModels_Id)
                .ForeignKey("dbo.RepuestoAccesorio", t => t.RepuestoAccesorioId, cascadeDelete: true)
                .ForeignKey("dbo.Vehiculo", t => t.VehiculoId, cascadeDelete: true)
                .Index(t => t.VehiculoId)
                .Index(t => t.RepuestoAccesorioId)
                .Index(t => t.FacturaModels_Id);
            
            CreateTable(
                "dbo.Factura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        ValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false),
                        Nombre = c.String(nullable: false),
                        Telefono = c.Int(nullable: false),
                        Direccion = c.String(nullable: false),
                        Ciudad = c.String(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                        Rol = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Vehiculo",
                c => new
                    {
                        VehiculoId = c.Int(nullable: false, identity: true),
                        NombreVehiculo = c.String(nullable: false),
                        CantidadDisponible = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NumeroPuertas = c.Int(nullable: false),
                        Color = c.String(nullable: false),
                        Marca = c.String(nullable: false),
                        TipoAuto = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VehiculoId);
        }
        
        public override void Down()
        {
         
            DropForeignKey("dbo.DetalleFactura", "VehiculoId", "dbo.Vehiculo");
            DropForeignKey("dbo.DetalleCotizacion", "VehiculoId", "dbo.Vehiculo");
            DropForeignKey("dbo.DetalleFactura", "RepuestoAccesorioId", "dbo.RepuestoAccesorio");
            DropForeignKey("dbo.Factura", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Cotizacion", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.DetalleFactura", "FacturaModels_Id", "dbo.Factura");
            DropForeignKey("dbo.DetalleCotizacion", "RepuestoAccesorioId", "dbo.RepuestoAccesorio");
            DropForeignKey("dbo.DetalleCotizacion", "CotizacionModels_Id", "dbo.Cotizacion");
            DropIndex("dbo.Factura", new[] { "UsuarioId" });
            DropIndex("dbo.DetalleFactura", new[] { "FacturaModels_Id" });
            DropIndex("dbo.DetalleFactura", new[] { "RepuestoAccesorioId" });
            DropIndex("dbo.DetalleFactura", new[] { "VehiculoId" });
            DropIndex("dbo.DetalleCotizacion", new[] { "CotizacionModels_Id" });
            DropIndex("dbo.DetalleCotizacion", new[] { "RepuestoAccesorioId" });
            DropIndex("dbo.DetalleCotizacion", new[] { "VehiculoId" });
            DropIndex("dbo.Cotizacion", new[] { "UsuarioId" });
            DropTable("dbo.Vehiculo");
            DropTable("dbo.Usuario");
            DropTable("dbo.Factura");
            DropTable("dbo.DetalleFactura");
            DropTable("dbo.RepuestoAccesorio");
            DropTable("dbo.DetalleCotizacion");
            DropTable("dbo.Cotizacion");
        }
    }
}
