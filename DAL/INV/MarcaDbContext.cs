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
    public class MarcaDbContext : DbContext
    {
        public DbSet<MarcaDTO> Marcas { get; set; }

        public MarcaDbContext() : base(GetOptions()) { }

        private static DbContextOptions<MarcaDbContext> GetOptions()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SISFACDB"].ConnectionString;

            if (connectionString == null)
            {
                throw new InvalidOperationException("Cadena de conexión 'SISFACDB' no encontrada en App.config.");
            }

            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<MarcaDbContext>(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarcaDTO>().ToTable("inv_marca");
            modelBuilder.Entity<MarcaDTO>().HasKey(m => m.Id);
            modelBuilder.Entity<MarcaDTO>().Property(m => m.Descripcion).IsRequired().HasMaxLength(50);

            modelBuilder.Entity<MarcaDTO>()
                .Property(m => m.FechaCreacion)
                .HasColumnName("fecha_creacion");

            modelBuilder.Entity<MarcaDTO>()
                .Property(m =>m.UsuarioCrea)
                .HasColumnName("usuario_crea");

            modelBuilder.Entity<MarcaDTO>()
                .Property(m => m.FechaModificacion)
                .HasColumnName("fecha_modificacion");

            modelBuilder.Entity<MarcaDTO>()
                .Property(m => m.UsuarioModifica)
                .HasColumnName("usuario_modifica");

            modelBuilder.Entity<MarcaDTO>().Property(m => m.Estado).IsRequired();
        }
    }
}
