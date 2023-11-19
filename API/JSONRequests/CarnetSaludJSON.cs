using API.Clases;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.JSONRequests
{
    public class CarnetSaludJSON
    {
        public int CI { get; set; }
        public DateTime Fch_Emision { get; set; }

        public DateTime Fch_Vencimiento { get; set; }
        public string Comprobante { get; set; }

    }
}
