using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FE.W.Models
{
    public partial class ClinicaMedicaV1Context : DbContext
    {
        public ClinicaMedicaV1Context()
        {
        }

        public ClinicaMedicaV1Context(DbContextOptions<ClinicaMedicaV1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<CitasProgramadas> CitasProgramadas { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Expediente> Expediente { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<ReporteCitas> ReporteCitas { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=diagonalley.database.windows.net;Database=ClinicaMedicaV1;User Id=potter;Password=Qn5Yhbcb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citas>(entity =>
            {
                entity.HasKey(e => e.CodigoCitas)
                    .HasName("PK__citas__2314C68895D2444E");

                entity.ToTable("citas");

                entity.Property(e => e.CodigoCitas).HasColumnName("codigoCitas");

                entity.Property(e => e.Asunto)
                    .HasColumnName("asunto")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripsion)
                    .HasColumnName("descripsion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EsTodoElDia).HasColumnName("esTodoElDia");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.HoraInicio)
                    .HasColumnName("horaInicio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Horafin)
                    .HasColumnName("horafin")
                    .HasColumnType("datetime");

                entity.Property(e => e.TemaColor)
                    .HasColumnName("temaColor")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CitasProgramadas>(entity =>
            {
                entity.HasKey(e => e.CodigoCitaProgramadas)
                    .HasName("PK__citasPro__289B9F40C35A7FAB");

                entity.ToTable("citasProgramadas");

                entity.Property(e => e.CodigoCitaProgramadas).HasColumnName("codigoCitaProgramadas");

                entity.Property(e => e.CodigoCitasFk).HasColumnName("codigoCitasFK");

                entity.Property(e => e.CodigoDoctorFk).HasColumnName("codigoDoctorFK");

                entity.Property(e => e.CodigoPacienteFk).HasColumnName("codigoPacienteFK");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Padecimiento)
                    .HasColumnName("padecimiento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tratamiento)
                    .HasColumnName("tratamiento")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoCitasFkNavigation)
                    .WithMany(p => p.CitasProgramadas)
                    .HasForeignKey(d => d.CodigoCitasFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("codigoCitas_FK");

                entity.HasOne(d => d.CodigoDoctorFkNavigation)
                    .WithMany(p => p.CitasProgramadas)
                    .HasForeignKey(d => d.CodigoDoctorFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("codigoDoctor_FK");

                entity.HasOne(d => d.CodigoPacienteFkNavigation)
                    .WithMany(p => p.CitasProgramadas)
                    .HasForeignKey(d => d.CodigoPacienteFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("codigoPaciente_FK");
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(e => e.CodigoDireccion)
                    .HasName("PK__direccio__20DD3CC8589DF23B");

                entity.ToTable("direccion");

                entity.Property(e => e.CodigoDireccion).HasColumnName("codigoDireccion");

                entity.Property(e => e.Canton)
                    .IsRequired()
                    .HasColumnName("canton")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Distrito)
                    .IsRequired()
                    .HasColumnName("distrito")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasColumnName("provincia")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Resena)
                    .HasColumnName("resena")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.CodigoDoctor)
                    .HasName("PK__doctor__8636F2A6DC87A201");

                entity.ToTable("doctor");

                entity.Property(e => e.CodigoDoctor).HasColumnName("codigoDoctor");

                entity.Property(e => e.CodigoPersonaFk).HasColumnName("codigoPersonaFk");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.HasOne(d => d.CodigoPersonaFkNavigation)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.CodigoPersonaFk)
                    .HasConstraintName("codigoPersona_DFK");
            });

            modelBuilder.Entity<Expediente>(entity =>
            {
                entity.HasKey(e => e.CodigoExpediente)
                    .HasName("PK__expedien__86AE4895D5A1A1C7");

                entity.ToTable("expediente");

                entity.Property(e => e.CodigoExpediente).HasColumnName("codigoExpediente");

                entity.Property(e => e.CodigoCitaProgramadasFk).HasColumnName("codigoCitaProgramadasFK");

                entity.HasOne(d => d.CodigoCitaProgramadasFkNavigation)
                    .WithMany(p => p.Expediente)
                    .HasForeignKey(d => d.CodigoCitaProgramadasFk)
                    .HasConstraintName("codigoCitaProgramadas_FK");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.CodigoPaciente)
                    .HasName("PK__paciente__E3D69DBF2191B7B8");

                entity.ToTable("paciente");

                entity.Property(e => e.CodigoPaciente).HasColumnName("codigoPaciente");

                entity.Property(e => e.CodigoPersonaFk).HasColumnName("codigoPersonaFK");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.HasOne(d => d.CodigoPersonaFkNavigation)
                    .WithMany(p => p.Paciente)
                    .HasForeignKey(d => d.CodigoPersonaFk)
                    .HasConstraintName("codigoPersona_FK");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.CodigoPersona)
                    .HasName("PK__persona__4F53D43051D472CC");

                entity.ToTable("persona");

                entity.Property(e => e.CodigoPersona).HasColumnName("codigoPersona");

                entity.Property(e => e.CodigoDireccionFk).HasColumnName("codigoDireccionFK");

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Edad).HasColumnName("EDAD");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Identificacion)
                    .HasColumnName("identificacion")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasColumnName("primerApellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasColumnName("segundoApellido")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasColumnName("SEXO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoDireccionFkNavigation)
                    .WithMany(p => p.Persona)
                    .HasForeignKey(d => d.CodigoDireccionFk)
                    .HasConstraintName("codigoDireccion_FK");
            });

            modelBuilder.Entity<ReporteCitas>(entity =>
            {
                entity.HasKey(e => e.CodigoreporteCitas)
                    .HasName("PK__reporteC__7F21C231D52FAB63");

                entity.ToTable("reporteCitas");

                entity.Property(e => e.CodigoreporteCitas).HasColumnName("codigoreporteCitas");

                entity.Property(e => e.CodigoExpedienteFk).HasColumnName("codigoExpedienteFK");

                entity.HasOne(d => d.CodigoExpedienteFkNavigation)
                    .WithMany(p => p.ReporteCitas)
                    .HasForeignKey(d => d.CodigoExpedienteFk)
                    .HasConstraintName("codigoExpedienteFK_FK");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.CodigoTipoUsuario)
                    .HasName("PK__tipoUsua__3716EE2E2C22BF41");

                entity.ToTable("tipoUsuario");

                entity.Property(e => e.CodigoTipoUsuario).HasColumnName("codigoTipoUsuario");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.CodigoUsuario)
                    .HasName("PK__usuarios__620878892ABD7AB1");

                entity.ToTable("usuarios");

                entity.Property(e => e.CodigoUsuario).HasColumnName("codigoUsuario");

                entity.Property(e => e.CodigoPersonaFk).HasColumnName("codigoPersonaFK");

                entity.Property(e => e.Contrasena)
                    .HasColumnName("contrasena")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.TipoUsuarioFk).HasColumnName("tipoUsuarioFK");

                entity.HasOne(d => d.CodigoPersonaFkNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CodigoPersonaFk)
                    .HasConstraintName("codigoPersona_UFK");

                entity.HasOne(d => d.TipoUsuarioFkNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipoUsuarioFk)
                    .HasConstraintName("tipoUsuarioFK_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
