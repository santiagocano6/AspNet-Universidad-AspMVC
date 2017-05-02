using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concesoft.Models
{
    [Table("RepuestoAccesorio")]
    public class RepuestoAccesorioModels
    {
        [Key]
        public int RepuestoAccesorioId { get; set; }

        [Required]
        [Display(Name = "Nombre artículo")]
        public string NombreArticulo { get; set; }

        [Required]
        [Display(Name = "Cantidad disponible")]
        public int CantidadDisponible { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public TipoRepuestoAccesorio Tipo { get; set; }

        public virtual ICollection<DetalleFacturaModels> DetalleFacturaModels { get; set; }
        public virtual ICollection<DetalleCotizacionModels> DetalleCotizacionModels { get; set; }
    }

    public enum TipoRepuestoAccesorio
    {
        Repuesto = 1,
        Accesorio = 2
    }
}
