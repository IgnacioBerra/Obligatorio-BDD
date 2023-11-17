using API.Clases;
using API.Data;
using API.JSONRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                   
                
                    // _context.Database.ExecuteSql($"INSERT INTO dbo.logins (Password) VALUES ({f.Password})");
                    // var logId =   _context.logins.FromSql($"SELECT TOP 1 logId FROM dbo.logins ORDER BY logId DESC").First().LogId;
                      _context.Database.ExecuteSql($"INSERT INTO dbo.funcionarios (CI,nombre,apellido,fch_nacimiento,direccion,telefono,email,logId) VALUES ({f.CI},{f.Nombre},{f.Apellido},{f.Fch_Nacimiento},{f.Direccion},{f.Telefono},{f.Email},{2})");


                      _context.SaveChanges();
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return StatusCode(500);
                }
            

            return Ok();
        }

    }
}
