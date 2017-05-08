using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concesoft.Models
{
    [Table("Factura")]
    public class FacturaModels
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public virtual ClienteModels ClienteModels { get; set; }

        [Required]
        [Display(Name = "Valor total")]
        public decimal ValorTotal { get; set; }

        public virtual ICollection<DetalleFacturaModels> DetalleFacturaModels { get; set; }
    }
}
