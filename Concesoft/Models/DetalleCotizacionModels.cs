using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concesoft.Models
{
    [Table("DetalleCotizacion")]
    public class DetalleCotizacionModels
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Display(Name = "Cotizacion")]
        public int CotizacionId { get; set; }
        public virtual CotizacionModels CotizacionModels { get; set; }

        [Required]
        [Display(Name = "Vehículo")]
        public int VehiculoId { get; set; }
        public virtual VehiculoModels VehiculoModels { get; set; }

        [Required]
        [Display(Name = "Repuesto o accesorio")]
        public int RepuestoAccesorioId { get; set; }
        public virtual RepuestoAccesorioModels RepuestoAccesorioModels { get; set; }

        [Required]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Required]
        [Display(Name = "Valor total")]
        public decimal ValorTotal { get; set; }
    }
}
