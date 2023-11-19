using API.Clases;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.JSONRequests
{
    public class AgendaJson
    { 
            public DateTime Fch_Agenda { get; set; }
            public int CI { get; set; } 
    }
}

