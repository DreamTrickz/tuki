using Demo.DTO.INV;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.INV
{
    public class SubcategoriaDAL
    {
        private readonly SubcategoriaDbContext _context;
        
        public SubcategoriaDAL()
        {
            _context = new SubcategoriaDbContext();
        }

        // Método para obtener todas las subcategorías
        public List<SubcategoriaDTO> ObtenerSubcategorias()
        {
            return _context.Subcategorias.ToList();
        }

        // Método para obtener una subcategoría por su Id
        public SubcategoriaDTO ObtenerSubcategoriaPorId(int id)
        {            
            var subcategoria = _context.Subcategorias.FirstOrDefault(s => s.Id == id);

            if (subcategoria == null)
            {
                // Maneja el caso en el que no se encuentra la categoria
                throw new Exception($"No se encontró ninguna categoría con el ID {id}");
            }
            return subcategoria;
        }

        // Método para obtener todas las subcategorías con su respectiva categoría
        public List<SubcategoriaDTO> ObtenerSubcategoriasConCategoria()
        {
            return _context.Subcategorias
                           .Include(s => s.Categoria)  // Carga de la relación Categoria
                           .ToList();
        }

        public List<SubcategoriaDTO> ObtenerSubcategoriasPorCategoria(int categoriaId)
        {
            return _context.Subcategorias
                           .Where(s => s.CategoriaId == categoriaId)
                           .ToList();
        }

        public List<SubcategoriaDTO> ObtenerSubcategoriasConFiltro(string filtro)
        {
            using (var context = new SubcategoriaDbContext())
            {
                var subcategoriasFiltradas = context.Subcategorias
                    .Include(s => s.Categoria)
                    .Where(s => s.Descripcion.Contains(filtro)
                             || (s.Categoria != null && s.Categoria.Descripcion.Contains(filtro)))
                    .ToList();

                return subcategoriasFiltradas;
            }

        }

        // Método para insertar una nueva subcategoría
        public void InsertarSubcategoria(SubcategoriaDTO subcategoria)
        {
            _context.Subcategorias.Add(subcategoria);
            _context.SaveChanges();
        }

        // Método para actualizar una subcategoría existente
        public void ActualizarSubcategoria(SubcategoriaDTO subcategoria)
        {
            var subcategoriaExistente = _context.Subcategorias.FirstOrDefault(s => s.Id == subcategoria.Id);
            if (subcategoriaExistente != null)
            {
                subcategoriaExistente.Descripcion = subcategoria.Descripcion;
                subcategoriaExistente.CategoriaId = subcategoria.CategoriaId;
                subcategoriaExistente.Estado = subcategoria.Estado;

                _context.SaveChanges();
            }
        }

        // Método para eliminar una subcategoría
        public void EliminarSubcategoria(int id)
        {
            var subcategoria = _context.Subcategorias.FirstOrDefault(s => s.Id == id);
            if (subcategoria != null)
            {
                _context.Subcategorias.Remove(subcategoria);
                _context.SaveChanges();
            }
        }
    }
}
