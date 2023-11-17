using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace API.Clases
{
    public class Logins
    {
        [Key]
        public int LogId { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar contraseña")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string Password { get; set; }
    }
}
