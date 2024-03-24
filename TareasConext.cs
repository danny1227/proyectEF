namespace proyectef;
using proyectef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}
    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
        modelbuilder.Entity<Categoria>(categoria => 
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaID);
            categoria.Property(p=> p.nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=> p.descripcion);

        });

        modelbuilder.Entity<Tarea>(tarea => {
            tarea.ToTable("Tarea");
            //primary key
            tarea.HasKey(p => p.TareaId);
            //foreign key  
            tarea.HasOne(p=> p.Categoria)
                .WithMany(p => p.Tareas)
                .HasForeignKey(p => p.CategoriaId);
            //properties
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Descripcion).IsRequired();
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreacion);
            tarea.Ignore(p => p.Resumen);
        });

    }
}