using API.Clases;
using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataInfo _context;

        public LoginController(DataInfo data)
        {
            _context = data;
        }

        [HttpPost("Logeo")]
        public IActionResult Logeo(Logins objeto)
        {
            try
            {
                var login = _context.logins.FromSqlRaw($"SELECT logId,password FROM dbo.logins WHERE logId={objeto.LogId}");

                if (login == null) { return Unauthorized("No se han encontrado usuarios con el logId especificado."); }

                else
                {
                    if (login.First().Password == objeto.Password)
                    {

                        return Ok(new { message = objeto.LogId });
                    }
                    else
                    {
                        return Unauthorized("Credenciales incorrectas.");
                    }
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(string password)
        {        

            try
            {
                
               var ejecucion = _context.Database.ExecuteSql($"INSERT INTO dbo.logins (Password) VALUES ({password})");
               
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            
            _context.SaveChanges();
            return Ok();

        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int logId)
        {

            try
            {
                var ejecucion = _context.Database.ExecuteSql($"DELETE FROM dbo.logins WHERE logId={logId}");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            _context.SaveChanges();
            return Ok();

        }

        [HttpPut("ChangePassword")]
        public IActionResult ChangePassword(int logId,string oldPassword, string newPassword)
        {

            try
            {

                var login = _context.logins.FromSqlRaw($"SELECT logId,password FROM dbo.logins WHERE logId={logId}");

                if (login == null) { return Unauthorized("No se han encontrado usuarios con el logId especificado."); }

                else
                {
                    if (login.First().Password == oldPassword)
                    {

                         _context.Database.ExecuteSql($"UPDATE logins SET password={newPassword} WHERE logId={logId}");
                    }
                    else
                    {
                        return Unauthorized("Credenciales incorrectas.");
                    }
                }   

            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            _context.SaveChanges();
            return Ok();

        }



    }
}
