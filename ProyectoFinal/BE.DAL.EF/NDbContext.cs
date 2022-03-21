using API.Models;
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
                optionsBuilder.UseSqlServer("Server=tcp:diagonalley.database.windows.net,1433;Initial Catalog=ClinicaMedicaV1;Persist Security Info=False;User ID=potter;Password=Qn5Yhbcb;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}


