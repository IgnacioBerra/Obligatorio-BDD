using API.Clases;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.JSONRequests
{
    public class FuncionarioAgendaJSON
    {
       
        public int CI { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime Fch_Nacimiento { get; set; }

        public string Direccion { get; set; }

        public int Telefono { get; set; }

        public string Email { get; set; }

        public int LogId { get; set; }

        public int Nro { get; set; }
        public DateTime Fch_Agenda { get; set; }
    }
}
