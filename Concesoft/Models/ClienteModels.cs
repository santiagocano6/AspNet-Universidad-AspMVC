using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concesoft.Models
{
    [Table("Cliente")]
    public class ClienteModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Cedula")]
        public int ClienteId { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public int Telefono { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required]
        public string Ciudad { get; set; }

        public virtual ICollection<FacturaModels> FacturaModels { get; set; }
        public virtual ICollection<CotizacionModels> CotizacionModels { get; set; }
    }
}
