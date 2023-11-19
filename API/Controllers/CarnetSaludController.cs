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
    public class CarnetSaludController : ControllerBase
    {

        private readonly DataInfo _context;

        public CarnetSaludController(DataInfo data)
        {
            _context = data;
        }



        [HttpPost("AñadirCarnetSalud")]
        public IActionResult AñadirCarnetSalud(CarnetSaludJSON cs)
        {
            try
            {
                _context.Database.ExecuteSql($"INSERT INTO dbo.carnet_salud (CI,fch_emision,fch_vencimiento,comprobante) VALUES ({cs.CI},{cs.Fch_Emision},{cs.Fch_Vencimiento},{cs.Comprobante})");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
            return Ok();

        }

        [HttpGet("ConseguirCarnetSalud")]
        public List<CarnetSalud> ConseguirCarnetSalud()
        {
            try
            {
                return _context.carnetSalud.FromSqlRaw("SELECT * FROM dbo.carnet_salud").ToList();
                    

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<CarnetSalud>();
            }

        }
    }
}
