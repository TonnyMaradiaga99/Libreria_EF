using System;
using libreria.Models;
namespace libreria.Services;

public class GeneroService: IGeneroService
{
    //Inyeccion de dependencias
    LibreriaContext context;
    public GeneroService(LibreriaContext dbContext){
        context=dbContext;
    }

    //CRUD
    //CREATE - insertar a la BD
    // async await
    public async Task insertar(Genero inputGenero){
        inputGenero.GeneroId= Guid.NewGuid();
        await context.AddAsync(inputGenero);
        await context.SaveChangesAsync();
    }

    //READ - Obtener de la DB
    public IEnumerable<Genero> obtener(){
        return context.Genero;
    }

    //UPDATE
    public async Task actualizar(Guid id, Genero inputGenero){
        var Genero = context.Genero?.Find(id);
        if(Genero != null){
            Genero.nombre=inputGenero.nombre;
            await context.SaveChangesAsync();
        }
    }

    //DELETE
    public async Task eliminar(Guid id){
        var Genero = context.Genero?.Find(id);
        if(Genero != null){
            context.Remove(Genero);
            await context.SaveChangesAsync();
        }
    }
}

public interface IGeneroService{
    Task insertar(Genero inputGenero);
    IEnumerable<Genero> obtener();
    Task actualizar(Guid id, Genero Genero);
    Task eliminar(Guid id);
}