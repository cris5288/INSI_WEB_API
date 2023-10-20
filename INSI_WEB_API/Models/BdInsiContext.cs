using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace INSI_WEB_API.Models;

public partial class BdInsiContext : DbContext
{
    public BdInsiContext()
    {
    }

    public BdInsiContext(DbContextOptions<BdInsiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Historial> Historials { get; set; }

    public virtual DbSet<HistorialEstudiante> HistorialEstudiantes { get; set; }

    public virtual DbSet<HistorialTutor> HistorialTutors { get; set; }

    public virtual DbSet<Matricula> Matriculas { get; set; }

    public virtual DbSet<Tutores> Tutores { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("PK__Estudian__7ED3967890939AB9");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("ACTUALIZAR_ESTUDIANTE");
                    tb.HasTrigger("ELIMINAR_ESTUDIANTE");
                    tb.HasTrigger("EvitarEdadMenorIgualA10");
                    tb.HasTrigger("INSERTAR_ESTUDIANTE");
                    tb.HasTrigger("ValidarLongitudTelefono");
                });

            entity.Property(e => e.IdEstudiante)
                .ValueGeneratedNever()
                .HasColumnName("ID_estudiante");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EstaRepitiendoGrado)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Esta_Repitiendo_Grado");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.LugarNacimiento)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Lugar_Nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PartidaNacimiento)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Partida_Nacimiento");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UltimoGradoAprobado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Ultimo_Grado_Aprobado");
            entity.Property(e => e.ZonaRecidencial)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Zona_Recidencial");
        });

        modelBuilder.Entity<Historial>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Historial");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.IdMatricula).HasColumnName("ID_matricula");
            entity.Property(e => e.Usuario)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HistorialEstudiante>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Historial_ESTUDIANTE");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.IdEstudiante).HasColumnName("ID_estudiante");
            entity.Property(e => e.Usuario)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HistorialTutor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Historial_TUTOR");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.IdTutor).HasColumnName("ID_tutor");
            entity.Property(e => e.Usuario)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.HasKey(e => e.IdMatricula).HasName("PK__Matricul__1B102093C30472A5");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("ACTUALIZAR_MATRICULA");
                    tb.HasTrigger("ELIMINAR_MATRICULA");
                    tb.HasTrigger("INSERTAR_MATRICULA");
                });

            entity.Property(e => e.IdMatricula)
                .ValueGeneratedNever()
                .HasColumnName("ID_matricula");
            entity.Property(e => e.EstadoMatricula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Estado_Matricula");
            entity.Property(e => e.FechaMatricula)
                .HasColumnType("date")
                .HasColumnName("Fecha_Matricula");
            entity.Property(e => e.GradoSolicitado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Grado_Solicitado");
            entity.Property(e => e.IdEstudiante).HasColumnName("ID_estudiante");
            entity.Property(e => e.IdTutor).HasColumnName("ID_tutor");

            entity.HasOne(d => d.oEstudiante).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("FK__Matricula__ID_es__5CD6CB2B");

            entity.HasOne(d => d.oTutores).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdTutor)
                .HasConstraintName("FK__Matricula__ID_tu__5DCAEF64");
        });

        modelBuilder.Entity<Tutores>(entity =>
        {
            entity.HasKey(e => e.IdTutor).HasName("PK__Tutores__E6D3CB5217580288");

            entity.ToTable(tb =>
                {
                    tb.HasTrigger("ACTUALIZAR_TUTORES");
                    tb.HasTrigger("ELIMINAR_TUTOR");
                    tb.HasTrigger("INSERTAR_TUTOR");
                    tb.HasTrigger("ValidarLongitudTelefonoTutor");
                });

            entity.Property(e => e.IdTutor)
                .ValueGeneratedNever()
                .HasColumnName("ID_tutor");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IdEstudiante).HasColumnName("ID_estudiante");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RelacionConEstudiante)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Relacion_Con_Estudiante");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.oEstudiante).WithMany(p => p.Tutores)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("FK__Tutores__ID_estu__59FA5E80");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Usuario");

            entity.Property(e => e.ContraseñaEncriptada)
                .HasMaxLength(255)
                .HasColumnName("Contraseña_ENCRIPTADA");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
