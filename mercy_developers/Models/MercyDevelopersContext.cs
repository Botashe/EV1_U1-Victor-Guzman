using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace mercy_developers.Models;

public partial class MercyDevelopersContext : DbContext
{
    public MercyDevelopersContext()
    {
    }

    public MercyDevelopersContext(DbContextOptions<MercyDevelopersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuariosServicio> UsuariosServicios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServ).HasName("PRIMARY");

            entity.ToTable("servicios");

            entity.Property(e => e.IdServ)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("ID_serv");
            entity.Property(e => e.Disponibilidad)
                .HasMaxLength(45)
                .HasColumnName("disponibilidad");
            entity.Property(e => e.Estado)
                .HasMaxLength(45)
                .HasColumnName("estado");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ingreso");
            entity.Property(e => e.Precio)
                .HasMaxLength(45)
                .HasColumnName("precio");
            entity.Property(e => e.TipoServicio)
                .HasMaxLength(45)
                .HasColumnName("tipo_servicio");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Rut).HasName("PRIMARY");

            entity.ToTable("usuarios");

            entity.Property(e => e.Rut)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("RUT");
            entity.Property(e => e.Apellido)
                .HasMaxLength(45)
                .HasColumnName("apellido");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(45)
                .HasColumnName("ciudad");
            entity.Property(e => e.Correo)
                .HasMaxLength(45)
                .HasColumnName("correo");
            entity.Property(e => e.Fechahora)
                .HasColumnType("datetime")
                .HasColumnName("fechahora");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Pais)
                .HasMaxLength(45)
                .HasColumnName("pais");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.Telefono)
                .HasMaxLength(45)
                .HasColumnName("telefono");
            entity.Property(e => e.Usuarioscol)
                .HasMaxLength(45)
                .HasColumnName("usuarioscol");
        });

        modelBuilder.Entity<UsuariosServicio>(entity =>
        {
            entity.HasKey(e => new { e.UsuariosRut, e.ServiciosIdServ })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("usuarios_servicios");

            entity.HasIndex(e => e.ServiciosIdServ, "fk_usuarios_has_servicios_servicios1_idx");

            entity.HasIndex(e => e.UsuariosRut, "fk_usuarios_has_servicios_usuarios_idx");

            entity.Property(e => e.UsuariosRut)
                .HasColumnType("int(11)")
                .HasColumnName("usuarios_RUT");
            entity.Property(e => e.ServiciosIdServ)
                .HasColumnType("int(11)")
                .HasColumnName("servicios_ID_serv");
            entity.Property(e => e.Duracion)
                .HasMaxLength(45)
                .HasColumnName("duracion");
            entity.Property(e => e.Estado)
                .HasMaxLength(45)
                .HasColumnName("estado");
            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecha_registro");
            entity.Property(e => e.HoraInicio)
                .HasColumnType("time")
                .HasColumnName("hora_inicio");
            entity.Property(e => e.HoraTermino)
                .HasColumnType("time")
                .HasColumnName("hora_termino");
            entity.Property(e => e.NombreTecnico)
                .HasMaxLength(45)
                .HasColumnName("nombre_tecnico");

            entity.HasOne(d => d.ServiciosIdServNavigation).WithMany(p => p.UsuariosServicios)
                .HasForeignKey(d => d.ServiciosIdServ)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usuarios_has_servicios_servicios1");

            entity.HasOne(d => d.UsuariosRutNavigation).WithMany(p => p.UsuariosServicios)
                .HasForeignKey(d => d.UsuariosRut)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_usuarios_has_servicios_usuarios");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
