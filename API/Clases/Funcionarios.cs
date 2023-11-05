using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Clases
{
    public class Funcionarios : DbContext
    {
        [Key]
        public int CI { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar nombre")]
        [StringLength(maximumLength: 60, MinimumLength = 2)]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar apellido")]
        [StringLength(maximumLength: 60, MinimumLength = 2)]
        public string apellido { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar fecha de nacimiento")]
        public DateOnly fechaNacimiento { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar direccion")]
        [StringLength(maximumLength: 200, MinimumLength = 2)]
        public string direccion { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar telefono")]
        public int telefono { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar fecha de nacimiento")]
        [StringLength(maximumLength: 120, MinimumLength = 3)]
        public string email { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar ID de logeo")]
        public int logId { get; set; }

        [ForeignKey("logId")]
        public Logins Log { get; set; }
    }
}
