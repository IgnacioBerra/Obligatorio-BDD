using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Clases
{
    public class Agenda
    {
        [Key]
        public int Nro { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar fecha de agenda ")]
        public DateTime Fch_Agenda { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar cedula de identidad ")]
        [ForeignKey("Funcionarios")]
        public int CI { get; set; }
        public Funcionarios Funcionarios { get; set; }  
    }
}
