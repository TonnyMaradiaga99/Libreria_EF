using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libreria.Models;

public class Genero
{

    [Key]
    public Guid GeneroId { get; set; }

    [Required]
    [MaxLength(250)]
    public String nombre { get; set; }

}