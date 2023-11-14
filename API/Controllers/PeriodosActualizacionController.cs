using API.Data;
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

        [HttpPost("AddDate")]
        public IActionResult addDate(DateTime fecha)
        {



            try
            {
                //var login = _context.periodosActualizacion.FromSqlRaw();

                
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
            return Ok();

        }
    }
}
