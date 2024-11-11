using Demo.DAL.INV;
using Demo.DTO.INV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.INV
{
    public class SubcategoriaBL
    {
        private readonly SubcategoriaDAL _subcategoriaDal;

        // Constructor que recibe la instancia de SubcategoriaDAL
        public SubcategoriaBL()
        {
            _subcategoriaDal = new SubcategoriaDAL();
        }

        // Método para obtener todas las subcategorías
        public List<SubcategoriaDTO> ObtenerSubcategorias()
        {
            return _subcategoriaDal.ObtenerSubcategorias();
        }

        // Método para obtener las subcategorías con sus categorías asociadas
        public List<SubcategoriaDTO> ObtenerSubcategoriasConCategoria()
        {
            return _subcategoriaDal.ObtenerSubcategoriasConCategoria();
        }

        public List<SubcategoriaDTO> ObtenerSubcategoriasPorCategoria(int categoriaId)
        {
            return _subcategoriaDal.ObtenerSubcategoriasPorCategoria(categoriaId);
        }

        public List<SubcategoriaDTO> ObtenerSubcategoriasConFiltro(string filtro)
        {
            return _subcategoriaDal.ObtenerSubcategoriasConFiltro(filtro);
        }


        // Método para obtener una subcategoría por Id
        public SubcategoriaDTO ObtenerSubcategoriaPorId(int id)
        {
            return _subcategoriaDal.ObtenerSubcategoriaPorId(id);
        }

        // Método para agregar una nueva subcategoría
        public void GuardarSubcategoria(string descripcion, int categoriaId, bool estado)
        {
            var nuevaSubcategoria = new SubcategoriaDTO
            {
                Descripcion = descripcion,
                CategoriaId = categoriaId,
                Estado = estado                
            }; 

            _subcategoriaDal.InsertarSubcategoria(nuevaSubcategoria);
        }

        // Método para actualizar una subcategoría existente
        public void ActualizarSubcategoria(int id, string descripcion, int categoriaId, bool estado)
        {
            var subcategoriaExistente = _subcategoriaDal.ObtenerSubcategoriaPorId(id);
            if (subcategoriaExistente != null)
            {
                subcategoriaExistente.Descripcion = descripcion;
                subcategoriaExistente.CategoriaId = categoriaId;
                subcategoriaExistente.Estado = estado;

                _subcategoriaDal.ActualizarSubcategoria(subcategoriaExistente);
            }
        }

        // Método para eliminar una subcategoría por Id
        public void EliminarSubcategoria(int id)
        {
            _subcategoriaDal.EliminarSubcategoria(id);
        }
    }
}
