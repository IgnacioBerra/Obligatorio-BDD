using API.Clases;
using API.Data;
using API.JSONRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodosActualizacionController : ControllerBase
    {


        private readonly DataInfo _context;

        public PeriodosActualizacionController(DataInfo data)
        {
            _context = data;
        }

        [HttpPut("UpdateDate")]
        public IActionResult updateDate(PeriodoActualizacionJSON pa)
        {
            try
            {
                var date = _context.Database.ExecuteSql($"UPDATE dbo.periodos_actualizacion SET Fch_Inicio={pa.FechaNuevaInicio}, Fch_Fin={pa.FechaNuevaFin}, Semestre={pa.Semestre}, Año={pa.Año} WHERE Fch_Inicio={pa.FechaAnteriorInicio} AND Fch_Fin={pa.FechaAnteriorFin}");
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
            return Ok();
        }


        [HttpPost("AñadirFecha")]
        public IActionResult AñadirFecha(PeriodosActualizacion pa)
        {
            try
            {
                _context.Database.ExecuteSql($"INSERT INTO dbo.periodos_actualizacion (Fch_Inicio,Fch_Fin,Semestre,Año) VALUES ({pa.Fch_Inicio},{pa.Fch_Fin},{pa.Semestre},{pa.Año})");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);

            }
            return Ok();

        }


        [HttpGet("GetPeriodos")]
        public ActionResult<List<PeriodosActualizacion>> GetPeriodos()
        {
            try
            {
                var periodos = _context.periodosActualizacion.FromSqlRaw($"SELECT * FROM dbo.periodos_actualizacion").ToList();
                return Ok(periodos);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }

        }
    }
}
