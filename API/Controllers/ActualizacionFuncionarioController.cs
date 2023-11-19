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
    public class ActualizacionFuncionarioController : ControllerBase
    {
       
          private readonly DataInfo _context;

          public ActualizacionFuncionarioController(DataInfo data)
          {
              _context = data;
          }



        [HttpPost("AñadirActualizacion")]
        public IActionResult Añadir(ActualizacionJSON aj)
        {
            try
            {
                 _context.Database.ExecuteSql($"INSERT INTO dbo.Actualizacion_Funcionario (CI,fecha_actualizacion,completado) VALUES ({aj.CI},{aj.fecha_actualizacion},{aj.completado})");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);

            }
            return Ok();

        }

        [HttpGet("GetActualizaciones")]
        public List<ActualizacionFuncionario> GetActualizaciones()
        {
            try
            {
                return _context.actualizacion.FromSqlRaw($"SELECT CI,fecha_actualizacion,completado FROM dbo.actualizacion_funcionario").ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<ActualizacionFuncionario>();
            }
        }
    }
}
