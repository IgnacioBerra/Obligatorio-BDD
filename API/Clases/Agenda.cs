using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Clases
{
    public class Agenda: DbContext
    {
        [Key]
        public int nro { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar cedula de identidad ")]
        public int CI { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar fecha de agenda ")]
        public DateTime fechaAgenda { get; set; }

        [ForeignKey("CI")]
        public Funcionarios FuncId { get; set; }
    }
}
