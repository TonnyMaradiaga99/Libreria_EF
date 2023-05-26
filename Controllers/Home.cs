
using Microsoft.AspNetCore.Mvc;

namespace libreria.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController: ControllerBase
{
    LibreriaContext dbcontext;
    public HomeController(LibreriaContext db){
        dbcontext=db;
    }

    [HttpGet]
    [Route("ConnDB")]
    public IActionResult ConnDB(){
        dbcontext.Database.EnsureCreated();
        return Ok();
    }
}