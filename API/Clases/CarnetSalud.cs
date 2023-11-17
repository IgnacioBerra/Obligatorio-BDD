using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Clases
{
    public class CarnetSalud 
    {
        [Required(ErrorMessage = "Se requiere ingresar cedula de identidad")]
        [Key]
        public int CI { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar fecha de emision")]
        [Key]
        public DateTime Fch_Emision { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar fecha de vencimiento")]
        public DateTime Fch_Vencimiento { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar comprobante")]
        [StringLength(maximumLength:500, MinimumLength = 2)]
        public string Comprobante { get; set; }

        [ForeignKey("Funcionarios")]
        public int FuncCI { get; set; }
        public Funcionarios Funcionarios { get; set; }
    }
}
