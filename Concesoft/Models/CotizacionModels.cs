using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concesoft.Models
{
    [Table("Cotizacion")]
    public class CotizacionModels
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }
        public virtual UsuarioModels UsuarioModels { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public virtual ClienteModels ClienteModels { get; set; }

        [Required]
        [Display(Name = "Valor total")]
        public decimal ValorTotal { get; set; }

        public virtual ICollection<DetalleCotizacionModels> DetalleCotizacionModels { get; set; }
    }
}
