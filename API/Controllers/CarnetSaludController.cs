using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
