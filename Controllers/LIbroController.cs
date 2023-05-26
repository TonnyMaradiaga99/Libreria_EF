using System.Net;
using Microsoft.AspNetCore.Mvc;
using libreria.Models;
using libreria.Services;

namespace libreria.Controllers;

//ATRIBUTOS CONTROLLER
[ApiController]
[Route("api/[controller]")]

public class LibroController: ControllerBase
{

    ILibroService LibroService;
    public LibroController(ILibroService LibroGenero){
        LibroService=LibroGenero;
    }

    //CRUD API
    //ATRIBUTOS DE ENDPOINTS
    //CREATE
    [HttpPost]
    public IActionResult ingresarLibros([FromBody] Libro nuevoLibro){
        LibroService.insertar(nuevoLibro);
        return Ok();
    }

    //READ
    [HttpGet]
    public IActionResult mostrarLibro(){
        return Ok(LibroService.obtener());
    }

    //UPDATE
    [HttpPut("{id}")]
    public IActionResult actualizarLibros([FromBody] Libro LibroActualizar, Guid id){
        LibroService.actualizar(id,LibroActualizar);
        return Ok();
    }

    //DELETE
    [HttpDelete("{id}")]
    public IActionResult eliminarLibros(Guid id){
        LibroService.eliminar(id);
        return Ok();
    }
}