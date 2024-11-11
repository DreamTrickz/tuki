using Demo.DTO.INV;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Demo.DAL.INV
{
    public class CategoriaDbContext : DbContext
    {
        public DbSet<CategoriaDTO> Categorias { get; set; }

        public CategoriaDbContext() : base(GetOptions()) { }

        private static DbContextOptions<CategoriaDbContext> GetOptions()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SISFACDB"].ConnectionString;

            if (connectionString == null)
            {
                throw new InvalidOperationException("Cadena de conexión 'SISFACDB' no encontrada en App.config.");
            }

            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<CategoriaDbContext>(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<CategoriaDTO>().ToTable("inv_categoria");
             modelBuilder.Entity<CategoriaDTO>().HasKey(m => m.Id);
             modelBuilder.Entity<CategoriaDTO>().Property(m => m.Descripcion).IsRequired().HasMaxLength(50);
             modelBuilder.Entity<CategoriaDTO>().Property(m => m.Estado).IsRequired(); */
            modelBuilder.Entity<CategoriaDTO>().ToTable("inv_categoria");
            modelBuilder.Entity<CategoriaDTO>().HasKey(m => m.Id);
            modelBuilder.Entity<CategoriaDTO>().Property(m => m.Descripcion).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<CategoriaDTO>()
                .Property(m => m.FechaCreacion)
                .HasColumnName("fecha_creacion");

            modelBuilder.Entity<CategoriaDTO>()
                .Property(m => m.UsuarioCrea)
                .HasColumnName("usuario_crea");

            modelBuilder.Entity<CategoriaDTO>()
                .Property(m => m.FechaModificacion)
                .HasColumnName("fecha_modificacion");

            modelBuilder.Entity<CategoriaDTO>()
                .Property(m => m.UsuarioModifica)
                .HasColumnName("usuario_modifica");

            modelBuilder.Entity<CategoriaDTO>().Property(m => m.Estado).IsRequired();
        }
    }
}
