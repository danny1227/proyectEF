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
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add( new Categoria() { CategoriaID = Guid.Parse("9d4a9853-31fa-4db3-95ed-6fbac352d076"), nombre = "Hogar", descripcion = "Categoria de tareas de hogar", esfuerzo = 2, etiqueta = 0});
        categoriasInit.Add( new Categoria() { CategoriaID = Guid.Parse("9d4a9853-31fa-4db3-95ed-6fbac352d078"), nombre = "Salud", descripcion = "Actividades personales", esfuerzo = 5, etiqueta = 0});

        modelbuilder.Entity<Categoria>(categoria => 
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaID);
            categoria.Property(p=> p.nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=> p.descripcion);
            categoria.Property(p=>p.esfuerzo);
            categoria.Property(p => p.etiqueta);

            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add(new Tarea() {TareaId = Guid.Parse("49ed54c2-b624-4974-96db-8d7caec5a82e"), CategoriaId = Guid.Parse("9d4a9853-31fa-4db3-95ed-6fbac352d076"), Titulo = "Realizar haceo", Descripcion = "Realizar tareas de hogar", PrioridadTarea = Prioridad.Baja, FechaCreacion = DateTime.Now});

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

            tarea.HasData(tareasInit);
        });

    }
}