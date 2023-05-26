using System.Net;
using Microsoft.AspNetCore.Mvc;
using libreria.Models;
using libreria.Services;

namespace libreria.Controllers
{

//ATRIBUTOS CONTROLLER
[ApiController]
[Route("api/[controller]")]
public class AutorController: ControllerBase
{

    IAutorService AutorService;
    public AutorController(IAutorService serviceAutor){
        AutorService=serviceAutor;
    }

    //CRUD API
    //ATRIBUTOS DE ENDPOINTS
    //CREATE
    [HttpPost]
    public async Task<IActionResult> postautor([FromBody] Autor newAutor){
        await AutorService.CreateAsync(newAutor);
        return Ok();
    }

    //READ
    [HttpGet]
    public IActionResult Get(){
        return Ok(AutorService.Get());
    }

    //UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] Autor updautor, Guid id){
        await AutorService.Update(id,updautor);
        return Ok();
    }

    //DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id){
        await AutorService.Delete(id);
        return Ok();
    }
}
}