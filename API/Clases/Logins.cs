using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace API.Clases
{
    public class Logins
    {
        [Key]
        public int logId { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar contraseña")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string password { get; set; }
    }
}
