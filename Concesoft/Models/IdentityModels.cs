using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Concesoft.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Rol { get; set; }

        public virtual ICollection<FacturaModels> FacturaModels { get; set; }
        public virtual ICollection<CotizacionModels> CotizacionModels { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<Concesoft.Models.ClienteModels> ClienteModels { get; set; }
        public System.Data.Entity.DbSet<Concesoft.Models.CotizacionModels> CotizacionModels { get; set; }
        public System.Data.Entity.DbSet<Concesoft.Models.DetalleCotizacionModels> DetalleCotizacionModels { get; set; }
        public System.Data.Entity.DbSet<Concesoft.Models.DetalleFacturaModels> DetalleFacturaModels { get; set; }
        public System.Data.Entity.DbSet<Concesoft.Models.FacturaModels> FacturaModels { get; set; }
        public System.Data.Entity.DbSet<Concesoft.Models.RepuestoAccesorioModels> RepuestoAccesorioModels { get; set; }
        public System.Data.Entity.DbSet<Concesoft.Models.UsuarioModels> UsuarioModels { get; set; }
        public System.Data.Entity.DbSet<Concesoft.Models.VehiculoModels> VehiculoModels { get; set; }

        public System.Data.Entity.DbSet<Concesoft.Models.ClienteModels> ClienteModels { get; set; }
    }
}