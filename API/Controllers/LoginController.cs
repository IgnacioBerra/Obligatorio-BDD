using System.Text;
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
        private readonly ILogger<LoginController> _logger;
        private readonly IRedisCache _cache;

        public LoginController(DataInfo data, ILogger<LoginController> logger, IRedisCache rcache)
        {
            _context = data;
            _logger = logger;
            _cache = rcache;
        }

        [HttpPost("Logeo")]
        public IActionResult Logeo(Logins objeto)
        {
            try
            {
                var byteData = _cache.GetUserRegistrationState(objeto.LogId.ToString());
                bool userInSystem= byteData != null;
                Console.WriteLine(userInSystem);                

                if (!userInSystem) { return Unauthorized("No se han encontrado usuarios con el logId especificado."); }

                else
                {
                    string pass = Encoding.UTF8.GetString(byteData);
                    if (pass == objeto.Password)
                    {

                        return Ok("Logeado correctamente");
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
            // PONER HASHEO
            try
            {
                
               var ejecucion = _context.Database.ExecuteSql($"INSERT INTO dbo.logins (Password) VALUES ({password})");
               
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            _cache.AddRegistration(password);
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
            _cache.deleteRegister(logId);
            _context.SaveChanges();
            return Ok();

        }

        [HttpPut("ChangePassword")]
        public IActionResult ChangePassword(int logId,string oldPassword, string newPassword)
        {

            try
            {
                
                var byteData = _cache.GetUserRegistrationState(logId.ToString());
                bool userInSystem= byteData != null;

                //var login = _context.logins.FromSqlRaw($"SELECT logId,password FROM dbo.logins WHERE logId={logId}");

                if (!userInSystem) { return Unauthorized("No se han encontrado usuarios con el logId especificado."); }

                else
                {
                    string pass = Encoding.UTF8.GetString(byteData);
                    if (pass == oldPassword)
                    {
                        _cache.ChangePassword(logId, newPassword);
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
