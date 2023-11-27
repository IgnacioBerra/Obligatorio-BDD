using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API.Clases
{
    public class ActualizacionFuncionario
    {

        [Required(ErrorMessage = "Se requiere ingresar cedula de identidad ")]
        [Key]
        public int CI { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar fecha de inicio")]
        public DateTime fecha_actualizacion { get; set; }

        [Required(ErrorMessage = "Se requiere conocer el estado del booleano")]
        public bool completado { get; set; }
    }
}
