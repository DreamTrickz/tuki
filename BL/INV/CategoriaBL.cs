using Demo.DAL.INV;
using Demo.DTO.INV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.INV
{
    public class CategoriaBL
    {
        private readonly CategoriaDAL _categoriaDal;

        public CategoriaBL()
        {
            _categoriaDal = new CategoriaDAL();
        }

        public List<CategoriaDTO> ObtenerCategorias()
        {
            return _categoriaDal.ObtenerCategorias();
        }

        public void GuardarCategoria(string descripcion, DateTime fechaCreacion, string usuarioCrea, bool estado)
        {
            var categoria = new CategoriaDTO
            {
                Descripcion = descripcion,
                FechaCreacion = fechaCreacion,
                UsuarioCrea = usuarioCrea,
                Estado = estado
            };

            _categoriaDal.InsertarCategoria(categoria);
        }
        public List<CategoriaDTO> ObtenerCategoriasConFiltro(string filtro)
        {
            return _categoriaDal.ObtenerCategoriasConFiltro(filtro);
        }
        public CategoriaDTO ObtenerCategoriaPorId(int id)
        {
            return _categoriaDal.ObtenerCategoriaPorId(id);
        }

        public void ActualizarCategoria(CategoriaDTO categoria)
        {
            _categoriaDal.ActualizarCategoria(categoria);
        }

        public void EliminarCategoria(int id)
        {
            _categoriaDal.EliminarCategoria(id);
        }
    }
}
