using API.Clases;
using API.Data;
using API.JSONRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly DataInfo _context;

        public FuncionariosController(DataInfo data)
        {
            _context = data;
        }

        [HttpPost("AddFuncionario")]
        public  ActionResult RegistrarFuncionario([FromBody] FuncionarioJSON f)
        {

                try
                {
                    
                      _context.Database.ExecuteSql($"INSERT INTO dbo.logins (Password) VALUES ({f.Password})");
                      var logId =   _context.logins.FromSql($"SELECT TOP 1 * FROM dbo.logins ORDER BY logId DESC").First().LogId;
                      _context.Database.ExecuteSql($"INSERT INTO dbo.funcionarios (CI,nombre,apellido,fch_nacimiento,direccion,telefono,email,logId) VALUES ({f.CI},{f.Nombre},{f.Apellido},{f.Fch_Nacimiento},{f.Direccion},{f.Telefono},{f.Email},{logId})");
                      _context.SaveChanges();
                      return Ok(new { message = logId });
            }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return StatusCode(500);
                }
            
        }

        [HttpGet("ConseguirFuncionarios")]
        public ActionResult<List<Funcionarios>> ConseguirFuncionarios()
        {
            try
            {
                var funcionarios = _context.funcionarios.FromSqlRaw($"SELECT * FROM dbo.funcionarios").ToList();
                return Ok(funcionarios);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }

        }

        [HttpGet("ConseguirFuncionariosAgenda")]
        public ActionResult<List<Funcionarios>> ConseguirFuncionariosAgenda()
        {
            try
            {
                var resultado = _context.funcionarios.FromSqlRaw($"SELECT DISTINCT funcionarios.* FROM dbo.funcionarios INNER JOIN dbo.agenda ON funcionarios.CI = agenda.CI").ToList();

                return Ok(resultado);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }

        }

        [HttpGet("ConseguirFuncionariosPorFecha")]
        public ActionResult<List<Funcionarios>> ConseguirFuncionariosPorFecha(string fecha )
        {
            try
            { 

                var resultado = _context.funcionarios.FromSqlRaw($"SELECT DISTINCT funcionarios.* FROM dbo.funcionarios INNER JOIN dbo.agenda ON funcionarios.CI = agenda.CI WHERE agenda.Fch_Agenda='{fecha}'").ToList();

                return Ok(resultado);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

    }
}
