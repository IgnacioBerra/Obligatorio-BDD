using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Clases
{
    public class Funcionarios 
    {
        [Key]
        public int CI { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar nombre")]
        [StringLength(maximumLength: 60, MinimumLength = 2)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar apellido")]
        [StringLength(maximumLength: 60, MinimumLength = 2)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar fecha de nacimiento")]
        public DateTime Fch_Nacimiento { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar direccion")]
        [StringLength(maximumLength: 200, MinimumLength = 2)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar telefono")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar fecha de nacimiento")]
        [StringLength(maximumLength: 120, MinimumLength = 3)]
        [EmailAddress(ErrorMessage = "Formato inválido")]
        public string Email { get; set; }

        [ForeignKey("Logins")]
        public int LogId { get; set; }

        public Logins Logins { get; set; }
     
     
    }
}
