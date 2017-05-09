namespace Concesoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DetalleFactura", "RepuestoAccesorioId", "dbo.RepuestoAccesorio");
            DropForeignKey("dbo.DetalleFactura", "VehiculoId", "dbo.Vehiculo");
            DropForeignKey("dbo.DetalleCotizacion", "RepuestoAccesorioId", "dbo.RepuestoAccesorio");
            DropForeignKey("dbo.DetalleCotizacion", "VehiculoId", "dbo.Vehiculo");
            DropIndex("dbo.DetalleFactura", new[] { "VehiculoId" });
            DropIndex("dbo.DetalleFactura", new[] { "RepuestoAccesorioId" });
            DropIndex("dbo.DetalleCotizacion", new[] { "VehiculoId" });
            DropIndex("dbo.DetalleCotizacion", new[] { "RepuestoAccesorioId" });
            AlterColumn("dbo.DetalleFactura", "VehiculoId", c => c.Int());
            AlterColumn("dbo.DetalleFactura", "RepuestoAccesorioId", c => c.Int());
            AlterColumn("dbo.DetalleCotizacion", "VehiculoId", c => c.Int());
            AlterColumn("dbo.DetalleCotizacion", "RepuestoAccesorioId", c => c.Int());
            CreateIndex("dbo.DetalleFactura", "VehiculoId");
            CreateIndex("dbo.DetalleFactura", "RepuestoAccesorioId");
            CreateIndex("dbo.DetalleCotizacion", "VehiculoId");
            CreateIndex("dbo.DetalleCotizacion", "RepuestoAccesorioId");
            AddForeignKey("dbo.DetalleFactura", "RepuestoAccesorioId", "dbo.RepuestoAccesorio", "RepuestoAccesorioId");
            AddForeignKey("dbo.DetalleFactura", "VehiculoId", "dbo.Vehiculo", "VehiculoId");
            AddForeignKey("dbo.DetalleCotizacion", "RepuestoAccesorioId", "dbo.RepuestoAccesorio", "RepuestoAccesorioId");
            AddForeignKey("dbo.DetalleCotizacion", "VehiculoId", "dbo.Vehiculo", "VehiculoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetalleCotizacion", "VehiculoId", "dbo.Vehiculo");
            DropForeignKey("dbo.DetalleCotizacion", "RepuestoAccesorioId", "dbo.RepuestoAccesorio");
            DropForeignKey("dbo.DetalleFactura", "VehiculoId", "dbo.Vehiculo");
            DropForeignKey("dbo.DetalleFactura", "RepuestoAccesorioId", "dbo.RepuestoAccesorio");
            DropIndex("dbo.DetalleCotizacion", new[] { "RepuestoAccesorioId" });
            DropIndex("dbo.DetalleCotizacion", new[] { "VehiculoId" });
            DropIndex("dbo.DetalleFactura", new[] { "RepuestoAccesorioId" });
            DropIndex("dbo.DetalleFactura", new[] { "VehiculoId" });
            AlterColumn("dbo.DetalleCotizacion", "RepuestoAccesorioId", c => c.Int(nullable: false));
            AlterColumn("dbo.DetalleCotizacion", "VehiculoId", c => c.Int(nullable: false));
            AlterColumn("dbo.DetalleFactura", "RepuestoAccesorioId", c => c.Int(nullable: false));
            AlterColumn("dbo.DetalleFactura", "VehiculoId", c => c.Int(nullable: false));
            CreateIndex("dbo.DetalleCotizacion", "RepuestoAccesorioId");
            CreateIndex("dbo.DetalleCotizacion", "VehiculoId");
            CreateIndex("dbo.DetalleFactura", "RepuestoAccesorioId");
            CreateIndex("dbo.DetalleFactura", "VehiculoId");
            AddForeignKey("dbo.DetalleCotizacion", "VehiculoId", "dbo.Vehiculo", "VehiculoId", cascadeDelete: true);
            AddForeignKey("dbo.DetalleCotizacion", "RepuestoAccesorioId", "dbo.RepuestoAccesorio", "RepuestoAccesorioId", cascadeDelete: true);
            AddForeignKey("dbo.DetalleFactura", "VehiculoId", "dbo.Vehiculo", "VehiculoId", cascadeDelete: true);
            AddForeignKey("dbo.DetalleFactura", "RepuestoAccesorioId", "dbo.RepuestoAccesorio", "RepuestoAccesorioId", cascadeDelete: true);
        }
    }
}
