using System;
using libreria.Models;
namespace libreria.Services;

public class LibroService: ILibroService
{
    //Inyeccion de dependencias
    LibreriaContext context;
    public LibroService(LibreriaContext dbContext){
        context=dbContext;
    }

    //CRUD
    //CREATE - insertar a la BD
    // async await
    public async Task insertar(Libro inputLibro){
        inputLibro.LibroId= Guid.NewGuid();
        await context.AddAsync(inputLibro);
        await context.SaveChangesAsync();
    }

    //READ - Obtener de la DB
    public IEnumerable<Libro> obtener(){
        return context.Libro;
    }

    //UPDATE
    public async Task actualizar(Guid id, Libro inputLibro){
        var Libro = context.Libro?.Find(id);
        if(Libro != null){
            Libro.nombre=inputLibro.nombre;
            Libro.edicion=inputLibro.edicion;
            Libro.paginas=inputLibro.paginas;

            await context.SaveChangesAsync();
        }
    }

    //DELETE
    public async Task eliminar(Guid id){
        var Libro = context.Libro?.Find(id);
        if(Libro != null){
            context.Remove(Libro);
            await context.SaveChangesAsync();
        }
    }

}

public interface ILibroService{
    Task insertar(Libro inputLibro);
    IEnumerable<Libro> obtener();
    Task actualizar(Guid id, Libro Libro);
    Task eliminar(Guid id);
}