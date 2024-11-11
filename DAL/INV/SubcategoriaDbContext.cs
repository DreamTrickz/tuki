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
    public class SubcategoriaDbContext : DbContext
    {
        public DbSet<SubcategoriaDTO> Subcategorias { get; set; }

        public SubcategoriaDbContext() : base(GetOptions()) { }

        private static DbContextOptions<SubcategoriaDbContext> GetOptions()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SISFACDB"].ConnectionString;

            if (connectionString == null)
            {
                throw new InvalidOperationException("Cadena de conexión 'SISFACDB' no encontrada en App.config.");
            }

            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<SubcategoriaDbContext>(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<SubcategoriaDTO>().ToTable("inv_subcategoria");
            // Definir la clave primaria
            modelBuilder.Entity<SubcategoriaDTO>().HasKey(s => s.Id);

            // Mapeo de la relación entre Subcategoria y Categoria
            modelBuilder.Entity<SubcategoriaDTO>()
                .HasOne(s => s.Categoria)
                .WithMany(c => c.Subcategorias)
                .HasForeignKey(s => s.CategoriaId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);  // Opcional: Define el comportamiento al eliminar una categoría
            
            // Mapeo de la propiedad CategoriaId a la columna id_categoria en la base de datos
            modelBuilder.Entity<SubcategoriaDTO>()
                .Property(s => s.CategoriaId)
                .HasColumnName("id_categoria");

            // Definir el resto de propiedades
            modelBuilder.Entity<SubcategoriaDTO>()
                .Property(s => s.Descripcion)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<SubcategoriaDTO>()
                .Property(s => s.Estado)
                .IsRequired();

            modelBuilder.Entity<CategoriaDTO>().ToTable("inv_categoria");

            modelBuilder.Entity<CategoriaDTO>().HasKey(c => c.Id);

            modelBuilder.Entity<CategoriaDTO>()
                .Property(c => c.Descripcion)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<CategoriaDTO>()
                .Property(c => c.Estado)
                .IsRequired();
        }        
    }
}
