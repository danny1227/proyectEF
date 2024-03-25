using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace proyectef.Models;

public class Categoria
{   
   // [Key]
    public Guid CategoriaID {get;set;}
    //[Required]
    //[MaxLength(150)]
    public string nombre {get;set;}
    //[MaxLength(300)]
    public string descripcion {get;set;}
    public int esfuerzo {get;set;}
    public int etiqueta {get;set;}
    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas {get;set;}
}