using Demo.DTO.INV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Demo.DAL.INV
{
    class UnidadMedidaDbContext : DbContext
    {
        public DbSet<UnidadMedidaDTO> UnidadMedidas { get; set; }

        public UnidadMedidaDbContext() : base(GetOptions()) { }

        private static DbContextOptions<UnidadMedidaDbContext> GetOptions()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SISFACDB"].ConnectionString;

            if (connectionString == null)
            {
                throw new InvalidOperationException("Cadena de conexión 'SISFACDB' no encontrada en App.config.");
            }

            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<UnidadMedidaDbContext>(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UnidadMedidaDTO>().ToTable("inv_unidad_medida");
            modelBuilder.Entity<UnidadMedidaDTO>().HasKey(m => m.Id);
            modelBuilder.Entity<UnidadMedidaDTO>().Property(m => m.Siglas).IsRequired().HasMaxLength(4);
            modelBuilder.Entity<UnidadMedidaDTO>().Property(m => m.Descripcion).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<UnidadMedidaDTO>()
                .Property(m => m.FechaCreacion)
                .HasColumnName("fecha_creacion");

            modelBuilder.Entity<UnidadMedidaDTO>()
                .Property(m => m.UsuarioCrea)
                .HasColumnName("usuario_crea");

            modelBuilder.Entity<UnidadMedidaDTO>()
                .Property(m => m.FechaModificacion)
                .HasColumnName("fecha_modificacion");

            modelBuilder.Entity<UnidadMedidaDTO>()
                .Property(m => m.UsuarioModifica)
                .HasColumnName("usuario_modifica");

            modelBuilder.Entity<UnidadMedidaDTO>().Property(m => m.Estado).IsRequired();
        }
    }
}
