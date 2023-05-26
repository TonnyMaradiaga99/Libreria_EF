using System;
using libreria.Models;
namespace libreria.Services;

public class AutorService: IAutorService
{
    //Inyeccion de dependencias
    LibreriaContext context;
    public AutorService(LibreriaContext dbContext){
        context=dbContext;
    }

    //CRUD
    //CREATE - insertar a la BD
    // async await
    public async Task CreateAsync(Autor newAutor){
        newAutor.AutorId= Guid.NewGuid();
        await context.AddAsync(newAutor);
        await context.SaveChangesAsync();
    }

    //READ - Obtener de la DB
    public IEnumerable<Autor> Get(){
        return context.Autor;
    }

    //UPDATE
    public async Task Update(Guid id, Autor updautor){
        var autor = context.Autor?.Find(id);
        if(autor != null){
            autor.nombre=updautor.nombre;
            autor.apellido=updautor.apellido;
            autor.nacionalidad=updautor.nacionalidad;
            await context.SaveChangesAsync();
        }
    }

    //DELETE
    public async Task Delete(Guid id){
        var autor = context.Autor?.Find(id);
        if(autor != null){
            context.Remove(autor);
            await context.SaveChangesAsync();
        }
    }
}

public interface IAutorService{
    Task CreateAsync(Autor newAutor);
    IEnumerable<Autor> Get();
    Task Update(Guid id, Autor autor);
    Task Delete(Guid id);
}