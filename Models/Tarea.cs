using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectef.Models;

public class Tarea
{
    [Key]
    public Guid TareaId {get;set;}
    [ForeignKey("CategoriaId")]
    public Guid CategoriaId {get;set;}
    [Required]
    [MaxLength(200)]
    public string Titulo {get;set;}
    [Required]
    public string Descripcion {get;set;}
    public Prioridad PrioridadTarea {get;set;}
    public DateTime FechaCreacion {get;set;}
    public virtual Categoria Categoria {get;set;}
    [NotMapped] //No se mapea
    public string Resumen {get;set;}
}

public enum Prioridad
{
    Baja,
    Media,
    Alta
}