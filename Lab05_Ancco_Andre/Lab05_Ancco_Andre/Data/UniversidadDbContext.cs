using System;
using System.Collections.Generic;
using Lab05_Ancco_Andre.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab05_Ancco_Andre.Data;

public partial class UniversidadDbContext : DbContext
{
    public UniversidadDbContext()
    {
    }

    public UniversidadDbContext(DbContextOptions<UniversidadDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencia> Asistencias { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Evaluacione> Evaluaciones { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    public virtual DbSet<Matricula> Matriculas { get; set; }

    public virtual DbSet<Profesore> Profesores { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql(
            "Host=aws-0-us-west-2.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.xmbjzstzatfxkxjcqykg;Password=andrefavio1235351;SSL Mode=Require;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone", "recovery_code" })
            .HasPostgresEnum("auth", "oauth_authorization_status", new[] { "pending", "approved", "denied", "expired" })
            .HasPostgresEnum("auth", "oauth_client_type", new[] { "public", "confidential" })
            .HasPostgresEnum("auth", "oauth_registration_type", new[] { "dynamic", "manual" })
            .HasPostgresEnum("auth", "oauth_response_type", new[] { "code" })
            .HasPostgresEnum("auth", "one_time_token_type", new[]
            {
                "confirmation_token",
                "reauthentication_token",
                "recovery_token",
                "email_change_token_new",
                "email_change_token_current",
                "phone_change_token"
            })
            .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
            .HasPostgresEnum("realtime", "equality_op", new[]
            {
                "eq", "neq", "lt", "lte", "gt", "gte", "in", "like", "ilike", "is", "match", "imatch", "isdistinct"
            })
            .HasPostgresEnum("storage", "buckettype", new[] { "STANDARD", "ANALYTICS", "VECTOR" })
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.HasKey(e => e.IdAsistencia)
                .HasName("asistencias_pkey");

            entity.ToTable("asistencias");

            entity.Property(e => e.IdAsistencia)
                .HasColumnName("id_asistencia");

            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasColumnName("estado");

            entity.Property(e => e.Fecha)
                .HasColumnName("fecha");

            entity.Property(e => e.IdCurso)
                .HasColumnName("id_curso");

            entity.Property(e => e.IdEstudiante)
                .HasColumnName("id_estudiante");

            entity.HasOne(d => d.IdCursoNavigation)
                .WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("asistencias_id_curso_fkey");

            entity.HasOne(d => d.IdEstudianteNavigation)
                .WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("asistencias_id_estudiante_fkey");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso)
                .HasName("cursos_pkey");

            entity.ToTable("cursos");

            entity.Property(e => e.IdCurso)
                .HasColumnName("id_curso");

            entity.Property(e => e.Creditos)
                .HasColumnName("creditos");

            entity.Property(e => e.Descripcion)
                .HasColumnName("descripcion");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante)
                .HasName("estudiantes_pkey");

            entity.ToTable("estudiantes");

            entity.Property(e => e.IdEstudiante)
                .HasColumnName("id_estudiante");

            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");

            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");

            entity.Property(e => e.Edad)
                .HasColumnName("edad");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Evaluacione>(entity =>
        {
            entity.HasKey(e => e.IdEvaluacion)
                .HasName("evaluaciones_pkey");

            entity.ToTable("evaluaciones");

            entity.Property(e => e.IdEvaluacion)
                .HasColumnName("id_evaluacion");

            entity.Property(e => e.Calificacion)
                .HasPrecision(5, 2)
                .HasColumnName("calificacion");

            entity.Property(e => e.Fecha)
                .HasColumnName("fecha");

            entity.Property(e => e.IdCurso)
                .HasColumnName("id_curso");

            entity.Property(e => e.IdEstudiante)
                .HasColumnName("id_estudiante");

            entity.HasOne(d => d.IdCursoNavigation)
                .WithMany(p => p.Evaluaciones)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("evaluaciones_id_curso_fkey");

            entity.HasOne(d => d.IdEstudianteNavigation)
                .WithMany(p => p.Evaluaciones)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("evaluaciones_id_estudiante_fkey");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.IdMateria)
                .HasName("materias_pkey");

            entity.ToTable("materias");

            entity.Property(e => e.IdMateria)
                .HasColumnName("id_materia");

            entity.Property(e => e.Descripcion)
                .HasColumnName("descripcion");

            entity.Property(e => e.IdCurso)
                .HasColumnName("id_curso");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdCursoNavigation)
                .WithMany(p => p.Materia)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("materias_id_curso_fkey");
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.HasKey(e => e.IdMatricula)
                .HasName("matriculas_pkey");

            entity.ToTable("matriculas");

            entity.Property(e => e.IdMatricula)
                .HasColumnName("id_matricula");

            entity.Property(e => e.IdCurso)
                .HasColumnName("id_curso");

            entity.Property(e => e.IdEstudiante)
                .HasColumnName("id_estudiante");

            entity.Property(e => e.Semestre)
                .HasMaxLength(20)
                .HasColumnName("semestre");

            entity.HasOne(d => d.IdCursoNavigation)
                .WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("matriculas_id_curso_fkey");

            entity.HasOne(d => d.IdEstudianteNavigation)
                .WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdEstudiante)
                .HasConstraintName("matriculas_id_estudiante_fkey");
        });

        modelBuilder.Entity<Profesore>(entity =>
        {
            entity.HasKey(e => e.IdProfesor)
                .HasName("profesores_pkey");

            entity.ToTable("profesores");

            entity.Property(e => e.IdProfesor)
                .HasColumnName("id_profesor");

            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");

            entity.Property(e => e.Especialidad)
                .HasMaxLength(100)
                .HasColumnName("especialidad");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("Users_pkey");

            entity.ToTable("Users");

            entity.Property(e => e.Id)
                .HasColumnName("Id");

            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("UserName");

            entity.Property(e => e.PasswordHash)
                .HasColumnName("PasswordHash");

            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("Role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}