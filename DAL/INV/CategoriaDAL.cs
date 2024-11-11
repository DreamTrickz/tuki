using Demo.DTO.INV;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.INV
{
    public class CategoriaDAL
    {
        private readonly CategoriaDbContext _context;

        public CategoriaDAL()
        {
            _context = new CategoriaDbContext();
        }

        public List<CategoriaDTO> ObtenerCategorias()
        {
            return _context.Categorias
                .Select(i => new CategoriaDTO
                {
                    Id = i.Id,
                    Descripcion = i.Descripcion,
                    FechaCreacion = i.FechaCreacion ?? null,
                    UsuarioCrea = i.UsuarioCrea ?? null,
                    // Manejo de campos opcionales
                    FechaModificacion = i.FechaModificacion ?? null,
                    UsuarioModifica = i.UsuarioModifica ?? null,
                    Estado = i.Estado
                })
                .ToList();
        }

        public List<CategoriaDTO> ObtenerCategoriasConFiltro(string filtro)
        {
            using (var context = new CategoriaDbContext())
            {
                var marcasFiltradas = context.Categorias
                    .Where(s => s.Descripcion.Contains(filtro))
                    .ToList();
                return marcasFiltradas;
            }

        }

        public void InsertarCategoria(CategoriaDTO categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
        }

        public CategoriaDTO ObtenerCategoriaPorId(int id)
        {           
            var categoria = _context.Categorias.FirstOrDefault(m => m.Id == id);

            if (categoria == null)
            {
                // Maneja el caso en el que no se encuentra la categoria
                throw new Exception($"No se encontró ninguna categoría con el ID {id}");
            }

            return categoria;

        }

        public void ActualizarCategoria(CategoriaDTO marca)
        {
            //_context.Marcas.Update(marca);
            //_context.SaveChanges();
            var entidadExistente = _context.Categorias.Local.FirstOrDefault(e => e.Id == marca.Id);

            if (entidadExistente != null)
            {
                _context.Entry(entidadExistente).State = EntityState.Detached; // Desadjuntar la entidad
            }

            _context.Entry(marca).State = EntityState.Modified; // Adjuntar y marcar como modificada
            _context.SaveChanges();
        }

        public void EliminarCategoria(int id)
        {
            var marca = _context.Categorias.FirstOrDefault(m => m.Id == id);
            if (marca != null)
            {
                _context.Categorias.Remove(marca);
                _context.SaveChanges();
            }
        }
    }
}
