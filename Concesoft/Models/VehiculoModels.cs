using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concesoft.Models
{
    [Table("Vehiculo")]
    public class VehiculoModels
    {
        [Key]
        public int VehiculoId { get; set; }

        [Required]
        [Display(Name = "Nombre vehículo")]
        public string NombreVehiculo { get; set; }

        [Required]
        [Display(Name = "Cantidad disponible")]
        public int CantidadDisponible { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        [Display(Name = "Número de puertas")]
        public int NumeroPuertas { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        [Display(Name = "Tipo auto")]
        public string TipoAuto { get; set; }

        public virtual ICollection<DetalleFacturaModels> DetalleFacturaModels { get; set; }
        public virtual ICollection<DetalleCotizacionModels> DetalleCotizacionModels { get; set; }
    }
}
