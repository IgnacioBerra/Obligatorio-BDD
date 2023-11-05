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

        public LoginController (DataInfo data)
        {
            _context = data;
        }

        [HttpGet("Logins")]
        public IActionResult getLogins()
        {
            var loginDetails = _context.logins.AsQueryable();
            return Ok(loginDetails);
        }
    }
}
