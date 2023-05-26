using System.Net;
using Microsoft.AspNetCore.Mvc;
using libreria.Models;
using libreria.Services;

namespace libreria.Controllers;

//ATRIBUTOS CONTROLLER
[ApiController]
[Route("api/[controller]")]

public class GeneroController: ControllerBase
{

    IGeneroService GeneroService;
    public GeneroController(IGeneroService ServiceGenero){
        GeneroService=ServiceGenero;
    }

    //CRUD API
    //ATRIBUTOS DE ENDPOINTS
    //CREATE
    [HttpPost]
    public IActionResult ingresarAutores([FromBody] Genero nuevoGenero){
        GeneroService.insertar(nuevoGenero);
        return Ok();
    }

    //READ
    [HttpGet]
    public IActionResult mostrarGenero(){
        return Ok(GeneroService.obtener());
    }

    //UPDATE
    [HttpPut("{id}")]
    public IActionResult actualizarGenero([FromBody] Genero GeneroActualizar, Guid id){
        GeneroService.actualizar(id,GeneroActualizar);
        return Ok();
    }

    //DELETE
    [HttpDelete("{id}")]
    public IActionResult eliminarGenero(Guid id){
        GeneroService.eliminar(id);
        return Ok();
    }
}