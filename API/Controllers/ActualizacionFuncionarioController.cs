using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.JSONRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using API.Clases;

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
            
          [HttpGet("getEmailsForNotification")]
          public IActionResult getEmailsForNotification()
          {
              try
              { 
                  var mails = _context.actualizacion.FromSqlRaw($"Select f.Email, f.CI FuncCI from dbo.Funcionarios f inner join dbo.Actualizacion_funcionario a on a.CI = f.CI where completado = 0");
                  string[] emails = new string[mails.Count()];
                  int i = 0;
                  foreach (var item in mails)
                  {
                      Console.WriteLine(item.ToString());
                      emails[i]=item.ToString();
                      i++;
                  }

              }
              catch (Exception e)
              {
                  Console.WriteLine(e.Message);
              }
              return Ok();
          }
        
    }
}
