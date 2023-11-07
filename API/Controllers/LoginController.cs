using API.Clases;
using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

            Logins objetoLogin = new Logins();
            objetoLogin.password = password;

            var creacion = _context.logins.Add(objetoLogin);

            _context.SaveChanges();

            return Ok(objetoLogin);

        }




    }
}
