using BE.DAL.DO.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BE.DAL.EF
{
    public partial class NDbContext : DbContext
    {
        public NDbContext()
        {
        }
        public NDbContext(DbContextOptions<NDbContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Biblioteca> Biblioteca { get; set; }
        public virtual DbSet<Enfermedades> Enfermedades { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Expedientes> Expedientes { get; set; }
        public virtual DbSet<Inventarios> Inventarios { get; set; }
        public virtual DbSet<Pagos> Pagos { get; set; }
        public virtual DbSet<SchedulerRecurringEvent> SchedulerRecurringEvent { get; set; }
        public virtual DbSet<TipoPago> TipoPago { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Biblioteca>(entity =>
            {
                entity.HasKey(e => e.IdVideo)
                    .HasName("PK__Bibliote__D2D0AD2A35816A9D");

                entity.Property(e => e.IdVideo).HasColumnName("idVideo");

                entity.Property(e => e.DescripcionVideo)
                    .HasColumnName("descripcionVideo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TituloVideo)
                    .HasColumnName("tituloVideo")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UrlVideo)
                    .HasColumnName("urlVideo")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Enfermedades>(entity =>
            {
                entity.HasKey(e => e.IdEnfermedad)
                    .HasName("PK__Enfermed__E8DAA00A71FBFBDC");

                entity.Property(e => e.IdEnfermedad).HasColumnName("idEnfermedad");

                entity.Property(e => e.Cedula)
                    .HasColumnName("cedula")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreEnfermedad)
                    .HasColumnName("nombreEnfermedad")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.CedulaNavigation)
                    .WithMany(p => p.Enfermedades)
                    .HasForeignKey(d => d.Cedula)
                    .HasConstraintName("FK__Enfermeda__cedul__38996AB5");
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.Property(e => e.Subject).HasMaxLength(100);

                entity.Property(e => e.ThemeColor).HasMaxLength(10);
            });

            modelBuilder.Entity<Expedientes>(entity =>
            {
                entity.HasKey(e => e.IdExpediente)
                    .HasName("PK__Expedien__ED873AE3717C0405");

                entity.Property(e => e.IdExpediente).HasColumnName("idExpediente");

                entity.Property(e => e.AnteFamiliares)
                    .HasColumnName("anteFamiliares")
                    .IsUnicode(false);

                entity.Property(e => e.AnteQuirurgicos)
                    .HasColumnName("anteQuirurgicos")
                    .IsUnicode(false);

                entity.Property(e => e.Antecendente)
                    .HasColumnName("antecendente")
                    .IsUnicode(false);

                entity.Property(e => e.Canton)
                    .HasColumnName("canton")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasColumnName("cedula")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .HasColumnName("ciudad")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Diagnostico)
                    .HasColumnName("diagnostico")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Distrito)
                    .HasColumnName("distrito")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaN)
                    .HasColumnName("fechaN")
                    .HasColumnType("date");

                entity.Property(e => e.Fracturas)
                    .HasColumnName("fracturas")
                    .IsUnicode(false);

                entity.Property(e => e.MediUtilizados)
                    .HasColumnName("mediUtilizados")
                    .IsUnicode(false);

                entity.HasOne(d => d.CedulaNavigation)
                    .WithMany(p => p.Expedientes)
                    .HasForeignKey(d => d.Cedula)
                    .HasConstraintName("FK__Expedient__cedul__671F4F74");
            });

            modelBuilder.Entity<Inventarios>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Inventar__07F4A1323E53BFB0");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.CodigoBarras)
                    .HasColumnName("codigoBarras")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaExpiracion)
                    .HasColumnName("fechaExpiracion")
                    .HasColumnType("date");

                entity.Property(e => e.NombreProducto)
                    .HasColumnName("nombreProducto")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Notas)
                    .HasColumnName("notas")
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoProducto).HasColumnName("tipoProducto");

                entity.HasOne(d => d.TipoProductoNavigation)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.TipoProducto)
                    .HasConstraintName("FK__Inventari__tipoP__398D8EEE");
            });

            modelBuilder.Entity<Pagos>(entity =>
            {
                entity.HasKey(e => e.IdPago)
                    .HasName("PK__Pagos__BD2295AD62EAEE6F");

                entity.Property(e => e.IdPago).HasColumnName("idPago");

                entity.Property(e => e.Banco)
                    .HasColumnName("banco")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasColumnName("cedula")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaPago)
                    .HasColumnName("fechaPago")
                    .HasColumnType("datetime");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.Notas)
                    .HasColumnName("notas")
                    .IsUnicode(false);

                entity.Property(e => e.TipoPago).HasColumnName("tipoPago");

                entity.HasOne(d => d.CedulaNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.Cedula)
                    .HasConstraintName("FK__Pagos__cedula__3A81B327");

                entity.HasOne(d => d.TipoPagoNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.TipoPago)
                    .HasConstraintName("FK__Pagos__tipoPago__3B75D760");
            });

            modelBuilder.Entity<SchedulerRecurringEvent>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EventPid).HasColumnName("EventPID");

                entity.Property(e => e.RecType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Text)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoPago>(entity =>
            {
                entity.HasKey(e => e.TipoPago1)
                    .HasName("PK__TipoPago__A7F8024CDE49A0A5");

                entity.Property(e => e.TipoPago1).HasColumnName("tipoPago");

                entity.Property(e => e.NombrePago)
                    .HasColumnName("nombrePago")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.HasKey(e => e.TipoProducto1)
                    .HasName("PK__TipoProd__B935A5F2A946A852");

                entity.Property(e => e.TipoProducto1)
                    .HasColumnName("tipoProducto")
                    .ValueGeneratedNever();

                entity.Property(e => e.NombreTipoProducto)
                    .HasColumnName("nombreTipoProducto")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__03006BFF26F0F834");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.TipoUsuario1)
                    .HasColumnName("tipoUsuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Cedula)
                    .HasName("PK__Usuario__415B7BE44D67B5CB");

                entity.Property(e => e.Cedula)
                    .HasColumnName("cedula")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Apellidos)
                    .HasColumnName("apellidos")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasenna)
                    .HasColumnName("contrasenna")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__idTipoU__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
