using Microsoft.EntityFrameworkCore;
using Modelo.Escuela;
using System;

namespace Persistencia
{
    public class EscuelaContext: DbContext
    {
        // Clases tipo entidad 
        public DbSet<Estudiante>    estudiantes     { get; set; }
        public DbSet<Curso>         cursos          { get; set; }
        public DbSet<Materia>       materias        { get; set; }
        public DbSet<Matricula>     matriculas      { get; set; }
        public DbSet<Matricula_Det> matriculas_Det  { get; set; }
        public DbSet<Calificacion>  calificaciones  { get; set; }
        public DbSet<Carrera>       carreras        { get; set; }
        public DbSet<Malla>         mallas          { get; set; }  
        public DbSet<Periodo>       periodos        { get; set; }
        public DbSet<Prerequisito>  prerequisitos   { get; set; }
        public DbSet<Configuracion> configuracion   { get; set; }

        // Constructor vacio
        public EscuelaContext():base() 
        { 

        }

        // Constructor para pasar la conexión al padre
        public EscuelaContext(DbContextOptions<EscuelaContext> opciones) 
            : base(opciones) 
        {

        }
        // Se mantiene para la creación de la base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                EscuelaConfig.ContextOptions(optionsBuilder);
            }
        }

        // Configuración del modelo de objetos tipo entidad
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuracion
            modelBuilder.Entity<Configuracion>()
                .HasOne(config => config.PeriodoVigente)
                .WithMany()
                .HasForeignKey(config => config.PeriodoVigenteId);                

            // Relación uno a muchos; un Estudiante tiene muchas Matrículas 
            modelBuilder.Entity<Matricula>()
                .HasOne(mat => mat.Estudiante)
                .WithMany(est => est.Matriculas)
                .HasForeignKey(mat => mat.EstudianteId);

            // Relación uno a muchos; una Matrícula a una carrera
            modelBuilder.Entity<Matricula>()
                .HasOne(mat => mat.Carrera)
                .WithMany(car => car.Matriculas)
                .HasForeignKey(mat => mat.CarreraId);

            // Relación uno a muchos; en un período se registran varias matrículas
            modelBuilder.Entity<Matricula>()
                .HasOne(mat => mat.Periodo)
                .WithMany(per => per.Matriculas)
                .HasForeignKey(mat => mat.PeriodoId);

            // Relación de uno a muchos: cabecera detalle de la matrícula
            modelBuilder.Entity<Matricula_Det>()
                .HasOne(det => det.Matricula)
                .WithMany(mat => mat.Matricula_Dets)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(det => det.MatriculaId);

            // Relación de uno a muchos: Cursos con detalles de la matrícula
            modelBuilder.Entity<Matricula_Det>()
                .HasOne(det => det.Curso)
                .WithMany(cur => cur.Matricula_Dets)
                .HasForeignKey(det => det.CursoId);

            // Relación uno a uno; una Matrícula_Det tiene una Calificación
            modelBuilder.Entity<Matricula_Det>()
                .HasOne(det => det.Calificacion)
                .WithOne(calif => calif.Matricula_Det)
                .HasForeignKey<Calificacion>(calif => calif.Matricula_DetId);

            // Relación uno a muchos; una Materia se dicta en muchos Cursos
            modelBuilder.Entity<Curso>()
                .HasOne(cur => cur.Materia)
                .WithMany(mat => mat.Cursos)
                .HasForeignKey(cur => cur.MateriaId);

            // Relación uno a muchos; una Carrera tiene varios Cursos
            modelBuilder.Entity<Curso>()
                .HasOne(cur => cur.Carrera)
                .WithMany(car => car.Cursos)
                .HasForeignKey(cur => cur.CarreraId);

            // Relación uno a muchos; un Período tiene varios cursos
            modelBuilder.Entity<Curso>()
                .HasOne(cur => cur.Periodo)
                .WithMany(per => per.Cursos)
                .HasForeignKey(cur => cur.PeriodoId);

            // Relación uno a uno de Malla con Materia
            modelBuilder.Entity<Malla>()
                .HasOne(malla => malla.Materia)
                .WithOne(mat => mat.Malla)
                .HasForeignKey<Malla>(malla => malla.MateriaId);

            // Relación Malla - Prerequisitos - Matrias
            modelBuilder.Entity<Prerequisito>()
                .HasKey(pre => new { pre.MallaId, pre.MateriaId });

            modelBuilder.Entity<Prerequisito>()
                .HasOne(pre => pre.Malla)
                .WithMany(malla => malla.PreRequisitos)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(pre => pre.MallaId);

            modelBuilder.Entity<Prerequisito>()
                .HasOne(pre => pre.Materia)
                .WithMany(mat => mat.Prerequisitos)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(pre => pre.MateriaId);
        }        
    }
}
