namespace Concesoft.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Concesoft.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Concesoft.Models.ApplicationDbContext";
        }

        protected override void Seed(Concesoft.Models.ApplicationDbContext context)
        {
            context.ClienteModels.AddOrUpdate(
              new ClienteModels { ClienteId = 1, Nombre = "Andrew Peters", Ciudad = "Medellin", Direccion = "Cra 1", Telefono = 123 },
              new ClienteModels { ClienteId = 2, Nombre = "Brice Lambson", Ciudad = "Itagui", Direccion = "Cra 2", Telefono = 123 },
              new ClienteModels { ClienteId = 3, Nombre = "Rowan Miller", Ciudad = "Bello", Direccion = "Cra 3", Telefono = 123 }
            );

            context.VehiculoModels.AddOrUpdate(
              new VehiculoModels { VehiculoId = 1, NombreVehiculo = "Clio", Marca = "Renault", Color = "Rojo", TipoAuto = "Sedan", CantidadDisponible = 100, NumeroPuertas = 4, Valor = 35000000 },
              new VehiculoModels { VehiculoId = 2, NombreVehiculo = "9", Marca = "Renault", Color = "Azul", TipoAuto = "Sedan", CantidadDisponible = 100, NumeroPuertas = 4, Valor = 9000000 }
            );

            context.RepuestoAccesorioModels.AddOrUpdate(
              new RepuestoAccesorioModels { RepuestoAccesorioId = 1, NombreArticulo = "Sonido", Tipo = TipoRepuestoAccesorio.Accesorio, CantidadDisponible = 100, Valor = 35000000 },
              new RepuestoAccesorioModels { RepuestoAccesorioId = 2, NombreArticulo = "Llanta", Tipo = TipoRepuestoAccesorio.Repuesto, CantidadDisponible = 100, Valor = 9000000 }
            );
        }
    }
}
