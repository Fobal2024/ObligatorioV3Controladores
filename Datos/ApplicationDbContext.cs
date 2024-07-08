using Microsoft.EntityFrameworkCore;
using Obligatorio.Models;
using System.Reflection.Emit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Obligatorio.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opciones)
        : base(opciones)
        {

        }
        public DbSet<TipoDeMaquina> TipoDeMaquina { get; set; } = default!;
        public DbSet<Socio> Socios { get; set; } = default!;
        public DbSet<Responsable> Responsables { get; set; } = default!;
        public DbSet<Maquina> Maquina { get; set; } = default!;
        public DbSet<Local> Local { get; set; } = default!;
        public DbSet<Ejercicio> Ejercicio { get; set; } = default!;
        public DbSet<TipoRutina> TipoRutinas { get; set; } = default!;
        public DbSet<Rutina> Rutinas { get; set; } = default!;
        public DbSet<SocioRutina> SocioRutinas { get; set; } = default!;
        public DbSet<RutinaEjercicio> RutinaEjercicio { get; set; } = default!; //Relación N-N (NO PERMITE CONTROLADOR)
        public object Maquinas { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Local = Categoría y Socio = Usuario. SOLO LO HAGO CON n-n Y n-1

            modelBuilder.Entity<SocioRutina>().HasKey(sr => new { sr.IdSocio, sr.IdRutina });

            modelBuilder.Entity<SocioRutina>()  // Relación N-N Usuario=Socio y Proyecto=Rutina
                .HasOne(sr => sr.Socio)
                .WithMany(s => s.SocioRutinas)
                .HasForeignKey(sr => sr.IdSocio);

            modelBuilder.Entity<SocioRutina>()   // Relación N-N
                .HasOne(sr => sr.Rutina)
                .WithMany(r => r.SocioRutinas)
                .HasForeignKey(sr => sr.IdRutina);

            modelBuilder.Entity<RutinaEjercicio>().HasKey(re => new { re.IdRutina, re.IdEjercicio }); //RutinaEjercicio

            modelBuilder.Entity<RutinaEjercicio>()  // Relación N-N Socio=Rutina y Rutina=Ejercicio
                .HasOne(re => re.Rutina)
                .WithMany(r => r.RutinaEjercicios)
                .HasForeignKey(re => re.IdRutina);

            modelBuilder.Entity<RutinaEjercicio>()   // Relación N-N
                .HasOne(re => re.Ejercicio)
                .WithMany(e => e.RutinaEjercicios)
                .HasForeignKey(re => re.IdEjercicio);

            modelBuilder.Entity<Rutina>()
                .HasOne(r => r.TipoRutina)
                .WithMany(tr => tr.Rutinas)
                .HasForeignKey(r => r.IdTipoRutina);

            modelBuilder.Entity<Socio>()     // Relación N-1
                .HasOne(s => s.LocalAsociado)
                .WithMany(l => l.Socios)
                .HasForeignKey(l => l.LocalId);

            modelBuilder.Entity<Maquina>()     // Relación N-1
                .HasOne(m => m.Local)
                .WithMany(l => l.Maquinas)
                .HasForeignKey(l => l.LocalId);

            modelBuilder.Entity<Maquina>()     // Relación N-1
                .HasOne(m => m.TipoDeMaquina)
                .WithMany(t => t.Maquinas)
                .HasForeignKey(m => m.TipoDeMaquinaId);
            //.OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Socio>()
                .Property(s => s.IdTipoRutina)
                .HasColumnName("IdTipoRutina");


            modelBuilder.Entity<Ejercicio>().HasData(
                new Ejercicio { Id = 1, Nombre = "Remo" },
                new Ejercicio { Id = 2, Nombre = "Sentadilla" },
                new Ejercicio { Id = 3, Nombre = "Jalon de Pecho" },
                new Ejercicio { Id = 4, Nombre = "Abdominales" },
                new Ejercicio { Id = 5, Nombre = "Bicicleta" },
                new Ejercicio { Id = 6, Nombre = "Caminar en Cinta" },
                new Ejercicio { Id = 7, Nombre = "Peso Muerto" }
                );

            modelBuilder.Entity<Local>().HasData(
                new Local { Id = 1, Nombre = "Local 1", Ciudad = "Colonia", Direccion = "Artigas1190", Telefono = "45220047", ResponsableId = 1 },
                new Local { Id = 2, Nombre = "Local 2", Ciudad = "Carmelo", Direccion = "Rivera 1866", Telefono = "3827562", ResponsableId = 2 },
                new Local { Id = 3, Nombre = "Local 3", Ciudad = "Nueva Palmira", Direccion = "Lavalleja 1654", Telefono = "1847162", ResponsableId = 3 },
                new Local { Id = 4, Nombre = "Local 4", Ciudad = "Juan Lacaze", Direccion = "Gral. Flores 1452", Telefono = "2837426", ResponsableId = 4 },
                new Local { Id = 5, Nombre = "Local 5", Ciudad = "Nueva Helvecia", Direccion = "Montevideo 1164", Telefono = "823746", ResponsableId = 5 },
                new Local { Id = 6, Nombre = "Local 6", Ciudad = "Rosario", Direccion = "Argentina 1526", Telefono = "23874623", ResponsableId = 6 },
                new Local { Id = 7, Nombre = "Local 7", Ciudad = "Colonia Valdense", Direccion = "Ruta 1 y Manton", Telefono = "283746", ResponsableId = 7 }
               );

            modelBuilder.Entity<Maquina>().HasData(
                new Maquina { IdMaquina = 1, FechaCompra = new DateTime(2022, 12, 22, 12, 15, 0), PrecioCompra = 15000, VidaUtil = 6, Disponible = true, TipoDeMaquinaId = 1, LocalId = 1 },
                new Maquina { IdMaquina = 2, FechaCompra = new DateTime(2023, 06, 05, 09, 49, 0), PrecioCompra = 17400, VidaUtil = 6, Disponible = true, TipoDeMaquinaId = 2, LocalId = 4 },
                new Maquina { IdMaquina = 3, FechaCompra = new DateTime(2024, 03, 21, 14, 51, 0), PrecioCompra = 23050, VidaUtil = 5, Disponible = true, TipoDeMaquinaId = 3, LocalId = 5 },
                new Maquina { IdMaquina = 4, FechaCompra = new DateTime(2022, 09, 05, 13, 55, 0), PrecioCompra = 26000, VidaUtil = 7, Disponible = true, TipoDeMaquinaId = 5, LocalId = 5 },
                new Maquina { IdMaquina = 5, FechaCompra = new DateTime(2023, 12, 15, 08, 56, 0), PrecioCompra = 30000, VidaUtil = 4, Disponible = false, TipoDeMaquinaId = 7, LocalId = 6 }
                );

            modelBuilder.Entity<Responsable>().HasData(
                  new Responsable { Id = 1, Nombre = "María Díaz", Telefono = "3457436" },
                  new Responsable { Id = 2, Nombre = "Ana Fernandez", Telefono = "43545428" },
                  new Responsable { Id = 3, Nombre = "Facundo Lopez", Telefono = "67254127" },
                  new Responsable { Id = 4, Nombre = "Flavia Rodriguez", Telefono = "32871451726" },
                  new Responsable { Id = 5, Nombre = "Karen Gonzalez", Telefono = "23572673" },
                  new Responsable { Id = 6, Nombre = "Nicolas Pereira", Telefono = "2387625" },
                  new Responsable { Id = 7, Nombre = "Marcelo Dominguez", Telefono = "127457615" }
                  );

            modelBuilder.Entity<Rutina>().HasData(
                  new Rutina { Id = 1, Descripcion = "Pecho", TipoRutina = null, CalificacionPromedio = 8, IdTipoRutina = 1 },
                  new Rutina { Id = 2, Descripcion = "Espalda", TipoRutina = null, CalificacionPromedio = 9, IdTipoRutina = 1 },
                  new Rutina { Id = 3, Descripcion = "Hombros", TipoRutina = null, CalificacionPromedio = 8, IdTipoRutina = 2 },
                  new Rutina { Id = 4, Descripcion = "Biceps", TipoRutina = null, CalificacionPromedio = 7, IdTipoRutina = 2 },
                  new Rutina { Id = 5, Descripcion = "Piernas", TipoRutina = null, CalificacionPromedio = 9, IdTipoRutina = 3 },
                  new Rutina { Id = 6, Descripcion = "Dorsales", TipoRutina = null, CalificacionPromedio = 8, IdTipoRutina = 3 }
                  );
            modelBuilder.Entity<TipoRutina>().HasData(
                  new TipoRutina { IdTipoRutina = 1, Nombre = "Salud" },
                  new TipoRutina { IdTipoRutina = 2, Nombre = "Competición Amateur" },
                  new TipoRutina { IdTipoRutina = 3, Nombre = "Competición Profesional" }
                  );

            modelBuilder.Entity<TipoDeMaquina>().HasData(
                  new TipoDeMaquina { Id = 1, Nombre = "Bicicleta fija" },
                  new TipoDeMaquina { Id = 2, Nombre = "Cinta Corredor" },
                  new TipoDeMaquina { Id = 3, Nombre = "Escaladora" },
                  new TipoDeMaquina { Id = 4, Nombre = "Máquina de Remo" },
                  new TipoDeMaquina { Id = 5, Nombre = "Prensa de Piernas" },
                  new TipoDeMaquina { Id = 6, Nombre = "Banco de Pecho" },
                  new TipoDeMaquina { Id = 7, Nombre = "Maquina Femorales" }
                  );

            modelBuilder.Entity<Socio>().HasData(
                   new Socio { Id = 1, Tipo = "Estandar", Email = "jsdfwheuu@gmail.com", LocalId = 1, Nombre = "Alberto Dalmas", Telefono = "23752" },
                   new Socio { Id = 2, Tipo = "Premium", Email = "hegfiweufgw@hotmail.com", LocalId = 5, Nombre = "Martina Perez", Telefono = "23874253" },
                   new Socio { Id = 3, Tipo = "Estandar", Email = "sbakjsfkjasf@hotmail.com", LocalId = 2, Nombre = "Carlos Dominicci", Telefono = "23764253" },
                   new Socio { Id = 4, Tipo = "Estandar", Email = "dhhdk@gmail.com", LocalId = 6, Nombre = "Pablo Ayala", Telefono = "375263" },
                   new Socio { Id = 5, Tipo = "Premium", Email = "fuhaiuhak@gmail.com", LocalId = 7, Nombre = "Daniela Chevalier", Telefono = "3172652" },
                   new Socio { Id = 6, Tipo = "Premium", Email = "hjgduwfyge@gmail.com", LocalId = 1, Nombre = "Manuela Sosa", Telefono = "8472364" }
                  );

            modelBuilder.Entity<SocioRutina>().HasData(
                  new SocioRutina { IdSocio = 1, IdRutina = 2, Calificacion = 8 },
                  new SocioRutina { IdSocio = 3, IdRutina = 3, Calificacion = 9 },
                  new SocioRutina { IdSocio = 1, IdRutina = 3, Calificacion = 8 }
                  );

            modelBuilder.Entity<RutinaEjercicio>().HasData(
                  new RutinaEjercicio { IdRutina = 1, IdEjercicio = 3, Repeticiones = 8, Series = 4 },
                  new RutinaEjercicio { IdRutina = 4, IdEjercicio = 7, Repeticiones = 10, Series = 3 },
                  new RutinaEjercicio { IdRutina = 2, IdEjercicio = 1, Repeticiones = 10, Series = 3 },
                  new RutinaEjercicio { IdRutina = 5, IdEjercicio = 5, Repeticiones = 12, Series = 4 }
            );
        }
    }
}

/*modelBuilder.Entity<Maquina>()     // Relación N-1
               .HasOne(m => m.Local)
               .WithMany(l => l.Maquinas)
               .HasForeignKey(l => l.LocalId);
// .OnDelete(DeleteBehavior.Restrict);*/