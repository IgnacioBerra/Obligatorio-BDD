using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Clases
{
    public class PeriodosActualizacion
    {
        [Required(ErrorMessage = "Se requiere ingresar año")]
        public int Año { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar semestre")]
        public int Semestre { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar fecha de inicio")]
        [Key]
        public DateTime Fch_Inicio { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar fecha de fin")]

        [Key]
        public DateTime Fch_Fin { get; set; }

    }
}
