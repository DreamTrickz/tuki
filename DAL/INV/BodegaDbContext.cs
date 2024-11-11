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
    public class BodegaDbContext : DbContext
    {
        public DbSet<BodegaDTO> Bodegas { get; set; }

        public BodegaDbContext() : base(GetOptions()) { }

        private static DbContextOptions<BodegaDbContext> GetOptions()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SISFACDB"].ConnectionString;

            if (connectionString == null)
            {
                throw new InvalidOperationException("Cadena de conexión 'SISFACDB' no encontrada en App.config.");
            }

            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<BodegaDbContext>(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BodegaDTO>().ToTable("inv_bodega");
            modelBuilder.Entity<BodegaDTO>().HasKey(m => m.Id);

            modelBuilder.Entity<BodegaDTO>().Property(m => m.IdTipoBodega)
                .HasColumnName("id_tipo_bodega"); // Mapea al nombre exacto de la columna en la base de datos

            modelBuilder.Entity<BodegaDTO>().Property(m => m.Codigo).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<BodegaDTO>().Property(m => m.Descripcion).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<BodegaDTO>()
                .Property(m => m.FechaCreacion)
                .HasColumnName("fecha_creacion");

            modelBuilder.Entity<BodegaDTO>()
                .Property(m => m.UsuarioCrea)
                .HasColumnName("usuario_crea");

            modelBuilder.Entity<BodegaDTO>()
                .Property(m => m.FechaModificacion)
                .HasColumnName("fecha_modificacion");

            modelBuilder.Entity<BodegaDTO>()
                .Property(m => m.UsuarioModifica)
                .HasColumnName("usuario_modifica");

            modelBuilder.Entity<BodegaDTO>().Property(m => m.Estado).IsRequired();
        }

    }
}
