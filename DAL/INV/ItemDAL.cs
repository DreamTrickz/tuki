using Demo.DTO.INV;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.INV
{
    public class ItemDAL
    {
        private readonly ItemDbContext _context;

        public ItemDAL()
        {
            // Inicializa el contexto sin necesidad de DbContextOptions
            _context = new ItemDbContext();
        }

        // Método para obtener todos los ítems
        public List<ItemDTO> ObtenerItems()
        {
            return _context.Items
                .Include(i => i.Marca)
                .Include(i => i.Categoria)
                .Include(i => i.Subcategoria)
                .Include(i => i.UnidadMedida)                
                .Select(i => new ItemDTO
                {
                    Id = i.Id,
                    Codigo = i.Codigo,
                    Descripcion = i.Descripcion,
                    MarcaId = i.MarcaId,
                    CategoriaId = i.CategoriaId,
                    SubcategoriaId = i.SubcategoriaId,
                    UnidadMedidaId = i.UnidadMedidaId,
                    StockGeneral = i.StockGeneral,
                    Costo = i.Costo,
                    Precio = i.Precio,
                    FechaCreacion = i.FechaCreacion,
                    UsuarioCrea = i.UsuarioCrea,
                    // Manejo de campos opcionales
                    FechaModificacion = i.FechaModificacion ?? null,
                    UsuarioModifica = i.UsuarioModifica ?? null,
                    Estado = i.Estado,

                    // Relaciones
                    Marca = i.Marca,
                    Categoria = i.Categoria,
                    Subcategoria = i.Subcategoria,
                    UnidadMedida = i.UnidadMedida
                })
                .AsNoTracking()  // No rastrear entidades en el contexto
                .ToList();
        }
        
        // Método para agregar un ítem
        public void AgregarItem(ItemDTO item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        // Método para actualizar un ítem
        public void ActualizarItem(ItemDTO item)
        {
            /*_context.Items.Update(item);
            _context.SaveChanges();*/
            var entidadExistente = _context.Items.Local.FirstOrDefault(e => e.Id == item.Id);

            if (entidadExistente != null)
            {
                _context.Entry(entidadExistente).State = EntityState.Detached; // Desadjuntar la entidad
            }

            _context.Entry(item).State = EntityState.Modified; // Adjuntar y marcar como modificada
            _context.SaveChanges();
        }

        // Método para eliminar un ítem
        public void EliminarItem(int id)
        {
            var item = _context.Items.Find(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }

        // Método para obtener un ítem por su ID
        public ItemDTO? ObtenerItemPorId(int id)
        {
            var item = _context.Items
                .Include(i => i.Marca)
                .Include(i => i.Categoria)
                .Include(i => i.Subcategoria)
                .Include(i => i.UnidadMedida)
                .FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                // Manejo del caso en que no se encuentra el ítem.
                // Puedes lanzar una excepción, devolver null o manejarlo según tu lógica.
                throw new InvalidOperationException("El ítem con el ID proporcionado no fue encontrado.");
            }

            return item;
        }
    }
}
