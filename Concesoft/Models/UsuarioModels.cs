using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Concesoft.Models
{
    [Table("Usuario")]
    public class UsuarioModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Cedula")]
        public int UsuarioId { get; set; }

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

        public string Login { get; set; }

        public string Password { get; set; }

        public string Rol { get; set; }

        public virtual ICollection<FacturaModels> FacturaModels { get; set; }
        public virtual ICollection<CotizacionModels> CotizacionModels { get; set; }

    }
}
