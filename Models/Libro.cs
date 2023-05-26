using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libreria.Models;

public class Libro
{
    [Key]
    public Guid LibroId { get; set; }

    [Required]
    [MaxLength(250)]
    public String nombre { get; set; }

    [MaxLength(250)]
    public int edicion { get; set; }

    [MaxLength(250)]
    public int paginas { get; set; }

    [ForeignKey("AutorId")]
    public Guid AutorId { get; set; }

    [ForeignKey("GeneroId")]
    public Guid GeneroId { get; set; }

}