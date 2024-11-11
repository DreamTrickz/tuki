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
    public class ItemDbContext : DbContext
    {
        public DbSet<ItemDTO> Items { get; set; }
        public DbSet<MarcaDTO> Marcas { get; set; }
        public DbSet<CategoriaDTO> Categorias { get; set; }
        public DbSet<SubcategoriaDTO> Subcategorias { get; set; }
        public DbSet<UnidadMedidaDTO> UnidadesMedida { get; set; }

        public ItemDbContext() : base(GetOptions())
        {
        }

        private static DbContextOptions<ItemDbContext> GetOptions()
        {
            // Lee la cadena de conexión desde el archivo de configuración
            var connectionString = ConfigurationManager.ConnectionStrings["SISFACDB"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Cadena de conexión 'SISFACDB' no encontrada en App.config.");
            }

            // Devuelve las opciones de contexto configuradas con SQL Server
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<ItemDbContext>(), connectionString).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemDTO>().ToTable("inv_item");

            modelBuilder.Entity<ItemDTO>().HasKey(s => s.Id);

            // Configuraciones de las relaciones entre las entidades
            modelBuilder.Entity<ItemDTO>()
                .HasOne(i => i.Marca)
                .WithMany()
                .HasForeignKey(s => s.MarcaId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);  // Opcional: Define el comportamiento al eliminar una marca

            modelBuilder.Entity<ItemDTO>()
                .HasOne(i => i.Marca)
                .WithMany()
                .HasForeignKey(i => i.MarcaId)
                .IsRequired();

            modelBuilder.Entity<ItemDTO>()
                .Property(i => i.MarcaId)
                .HasColumnName("id_marca");

            modelBuilder.Entity<ItemDTO>()
                .HasOne(i => i.Categoria)
                .WithMany()
                .HasForeignKey(i => i.CategoriaId)
                .IsRequired();                

            modelBuilder.Entity<ItemDTO>()
                .Property(i => i.CategoriaId)
                .HasColumnName("id_categoria");

            modelBuilder.Entity<ItemDTO>()
                .HasOne(i => i.Subcategoria)
                .WithMany()
                .HasForeignKey(i => i.SubcategoriaId)
                .IsRequired();

            modelBuilder.Entity<ItemDTO>()
                .Property(i => i.SubcategoriaId)
                .HasColumnName("id_subcategoria");

            modelBuilder.Entity<ItemDTO>()
                .HasOne(i => i.UnidadMedida)
                .WithMany()
                .HasForeignKey(i => i.UnidadMedidaId)
                .IsRequired();

            modelBuilder.Entity<ItemDTO>()
                .Property(i => i.UnidadMedidaId)
                .HasColumnName("id_unidad_medida");

            modelBuilder.Entity<ItemDTO>()
                .Property(i => i.StockGeneral).IsRequired()
                .HasColumnName("stock_general");
            //modelBuilder.Entity<ItemDTO>().Property(i => i.StockGeneral).HasColumnName("stock_general");

            modelBuilder.Entity<ItemDTO>()
                .Property(i => i.Costo).IsRequired()
                .HasColumnName("costo");
            //modelBuilder.Entity<ItemDTO>().Property(i => i.Costo).HasColumnName("costo");

            modelBuilder.Entity<ItemDTO>()
                .Property(i => i.Precio).IsRequired()
                .HasColumnName("precio");
            //modelBuilder.Entity<ItemDTO>().Property(i => i.Precio).HasColumnName("precio");

            modelBuilder.Entity<ItemDTO>()
                .Property(i => i.FechaCreacion).IsRequired()
                .HasColumnName("fecha_creacion");
            //modelBuilder.Entity<ItemDTO>().Property(i => i.FechaCreacion).HasColumnName("fecha_creacion");

            modelBuilder.Entity<ItemDTO>()
                .Property(i => i.UsuarioCrea).IsRequired()
                .HasColumnName("usuario_crea");
            //modelBuilder.Entity<ItemDTO>().Property(i => i.UsuarioCrea).HasColumnName("usuario_crea");

            modelBuilder.Entity<ItemDTO>()
                .Property(i => i.FechaModificacion)
                .HasColumnName("fecha_modificacion");
            //modelBuilder.Entity<ItemDTO>().Property(i => i.FechaModificacion).HasColumnName("fecha_modificacion");

            modelBuilder.Entity<ItemDTO>()
                .Property(i => i.UsuarioModifica)
                .HasColumnName("usuario_modifica");
            //modelBuilder.Entity<ItemDTO>().Property(i => i.UsuarioModifica).HasColumnName("usuario_modifica");

            modelBuilder.Entity<ItemDTO>()
                .Property(i => i.Estado).IsRequired();

            modelBuilder.Entity<MarcaDTO>()
                .ToTable("inv_marca")
                .HasKey(c => c.Id);
            //modelBuilder.Entity<MarcaDTO>().HasKey(c => c.Id);

            modelBuilder.Entity<MarcaDTO>()
                .Property(c => c.Descripcion)
                .HasColumnName("descripcion");

            modelBuilder.Entity<MarcaDTO>()
                .Property(c => c.FechaCreacion)
                .HasColumnName("fecha_creacion");

            modelBuilder.Entity<MarcaDTO>()
                .Property(c => c.UsuarioCrea)
                .HasColumnName("usuario_crea");

            modelBuilder.Entity<MarcaDTO>()
                .Property(c => c.FechaModificacion)
                .HasColumnName("fecha_modificacion");

            modelBuilder.Entity<MarcaDTO>()
                .Property(c => c.UsuarioModifica)
                .HasColumnName("usuario_modifica");

            modelBuilder.Entity<MarcaDTO>()
                .Property(c => c.Estado)
                .HasColumnName("estado");

            modelBuilder.Entity<CategoriaDTO>()
                .ToTable("inv_categoria")
                .HasKey(c => c.Id);
            //modelBuilder.Entity<CategoriaDTO>().HasKey(c => c.Id);

            modelBuilder.Entity<CategoriaDTO>()
                .Property(c => c.Descripcion)
                .HasColumnName("descripcion");
            
            modelBuilder.Entity<CategoriaDTO>()
                .Property(c => c.Estado)
                .HasColumnName("estado");

            modelBuilder.Entity<SubcategoriaDTO>()
                .ToTable("inv_subcategoria")
                .HasKey(c => c.Id);
            //modelBuilder.Entity<SubcategoriaDTO>().HasKey(c => c.Id);

            modelBuilder.Entity<SubcategoriaDTO>()
                .Property(c => c.CategoriaId)
                .HasColumnName("id_categoria");
            
            modelBuilder.Entity<SubcategoriaDTO>()
                .Property(c => c.Descripcion)
                .HasColumnName("descripcion");            
            
            modelBuilder.Entity<SubcategoriaDTO>()
                .Property(c => c.Estado)
                .HasColumnName("estado");

            modelBuilder.Entity<UnidadMedidaDTO>()
                .ToTable("inv_unidad_medida")
                .HasKey(c => c.Id);
            
            //modelBuilder.Entity<UnidadMedidaDTO>().HasKey(c => c.Id);
            modelBuilder.Entity<UnidadMedidaDTO>()
                .Property(c => c.Siglas)
                .HasColumnName("siglas");
            
            modelBuilder.Entity<UnidadMedidaDTO>()
                .Property(c => c.Descripcion)
                .HasColumnName("descripcion");
            
            modelBuilder.Entity<UnidadMedidaDTO>()
                .Property(c => c.Estado)
                .HasColumnName("estado");
        }
    }
}
