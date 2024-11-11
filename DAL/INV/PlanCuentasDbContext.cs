using Demo.DTO.INV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Demo.DAL.INV
{
    public class PlanCuentasDbContext : DbContext   
    {
        public DbSet<PlanCuentasDTO> PlanCuentass { get; set; }

        public PlanCuentasDbContext() : base(GetOptions()) { }

        private static DbContextOptions<PlanCuentasDbContext> GetOptions()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SISFACDB"].ConnectionString;

            if (connectionString == null)
            {
                throw new InvalidOperationException("Cadena de conexión 'SISFACDB' no encontrada en App.config.");
            }

            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<PlanCuentasDbContext>(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanCuentasDTO>().ToTable("con_plan_cuentas");
            modelBuilder.Entity<PlanCuentasDTO>().HasKey(m => m.Id);
            modelBuilder.Entity<PlanCuentasDTO>().Property(m => m.CodigoCuenta).HasColumnName("codigo_cuenta");
            modelBuilder.Entity<PlanCuentasDTO>().Property(m => m.NombreCuenta).HasColumnName("nombre_cuenta").IsRequired().HasMaxLength(20);
            modelBuilder.Entity<PlanCuentasDTO>().Property(m => m.TipoCuenta).HasColumnName("tipo_cuenta").IsRequired().HasMaxLength(15);

            modelBuilder.Entity<PlanCuentasDTO>()
                .Property(m => m.FechaCreacion)
                .HasColumnName("fecha_creacion");

            modelBuilder.Entity<PlanCuentasDTO>()
                .Property(m =>m.UsuarioCrea)
                .HasColumnName("usuario_crea");

            modelBuilder.Entity<PlanCuentasDTO>()
                .Property(m => m.FechaModificacion)
                .HasColumnName("fecha_modificacion");

            modelBuilder.Entity<PlanCuentasDTO>()
                .Property(m => m.UsuarioModifica)
                .HasColumnName("usuario_modifica");

            modelBuilder.Entity<PlanCuentasDTO>().Property(m => m.Estado).IsRequired();
        }
    }
}