using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Clases
{
    public class CarnetSalud : DbContext
    {
        [Required(ErrorMessage = "Se requiere ingresar cedula de identidad")]
        [Key]
        public int CI { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar fecha de emision")]
        [Key]
        public DateTime fechaEmision { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar fecha de vencimiento")]
        public DateTime fechaVencimiento { get; set; }

        [Required(ErrorMessage = "Se requiere ingresar comprobante")]
        [StringLength(maximumLength:500, MinimumLength = 2)]
        public string Comprobante { get; set; }

        [ForeignKey("CI")]
        public Funcionarios FuncCI { get; set; }
    }
}
