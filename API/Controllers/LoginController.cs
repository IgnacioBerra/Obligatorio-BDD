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
        public IActionResult Logeo(int id, int password)
        {

            var login = _context.logins.FirstOrDefault(user => user.logId == id);
            if (login == null) { return Unauthorized("No se han encontrado usuarios con el logId especificado."); }

            if (login.password == password)
            {
                
                return Ok("Logeado correctamente");
            }
            else
            {
                return Unauthorized("No se ha podido logear.");
            }
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(int password)
        {        

            try
            {
                //var res = _context.logins.FromSqlRaw(saveUser).First();
               var ejecucion = _context.Database.ExecuteSql($"INSERT INTO dbo.logins (Password) VALUES ({password})");
               
            }
            catch (Exception e )
            {
                return StatusCode(500);
            }
            
            _context.SaveChanges();
            return Ok();

        }




    }
}
