using System.Security.Cryptography;
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

        private string hashedPass(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                string hashedString = sb.ToString();
                return hashedString;
            }
        }
        
        [HttpPost("Logeo")]
        public IActionResult Logeo(Logins objeto)
        {
            try
            {
                var byteData = _cache.GetUserRegistrationState(objeto.LogId.ToString());
                bool userInSystem= byteData != null;

                if (!userInSystem) { return Unauthorized("No se han encontrado usuarios con el logId especificado."); }

                else
                {
                    string pass = Encoding.UTF8.GetString(byteData);
                    string hashedPass = this.hashedPass(objeto.Password);
                    if (hashedPass == pass)
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
            string hashedString = hashedPass(password);
            Console.WriteLine(hashedString);
                try
                {
                
                    var ejecucion = _context.Database.ExecuteSql($"INSERT INTO dbo.logins (Password) VALUES ({hashedString})");
               
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
                _cache.AddRegistration(hashedString);
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


                if (!userInSystem) { return Unauthorized("No se han encontrado usuarios con el logId especificado."); }

                else
                {
                    string pass = Encoding.UTF8.GetString(byteData);
                    string oldHashedPass = this.hashedPass(oldPassword);
                    if (pass == oldHashedPass)
                    {
                        string newHashedPass = this.hashedPass(newPassword);
                        _cache.ChangePassword(logId, newHashedPass);
                         _context.Database.ExecuteSql($"UPDATE logins SET password={newHashedPass} WHERE logId={logId}");
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
