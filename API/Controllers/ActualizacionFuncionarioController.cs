using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualizacionFuncionarioController : ControllerBase
    {
       
          private readonly DataInfo _context;

          public ActualizacionFuncionarioController(DataInfo data)
          {
              _context = data;
          }


        
    }
}
