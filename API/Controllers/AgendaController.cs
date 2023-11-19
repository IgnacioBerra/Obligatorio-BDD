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
    public class AgendaController : ControllerBase
    {
        private readonly DataInfo _context;

        public AgendaController(DataInfo data)
        {
            _context = data;
        }


        [HttpPost("addAgenda")]
        public ActionResult addAgenda(AgendaJson a)
        {

            try
            {
                var funcionario = _context.funcionarios.FromSql($"SELECT * FROM dbo.funcionarios WHERE CI={a.CI}").ToList();
                if (funcionario.Count == 0)
                {
                    return StatusCode(404);
                }
                else {
                    _context.Database.ExecuteSql($"INSERT INTO dbo.agenda (Fch_Agenda,CI) VALUES ({a.Fch_Agenda},{a.CI})");
                    _context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
            
        }

        [HttpGet("ConseguirAgenda")]
        public List<Agenda> ConseguirAgenda()
        {
            try
            {
                return _context.agenda.FromSqlRaw($"SELECT * FROM dbo.agenda").ToList();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Agenda>();
            }

        }
    }
}
