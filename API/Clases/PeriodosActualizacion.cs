using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Clases
{
    public class PeriodosActualizacion : DbContext
    {
        [Required(ErrorMessage = "Se requiere ingresar año")]
        public int año { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar semestre")]
        public int semestre { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar fecha de inicio")]
        [Key]
        public DateTime fechaInicio { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar fecha de fin")]

        [Key]
        public DateTime fechaFin { get; set; }

    }
}
