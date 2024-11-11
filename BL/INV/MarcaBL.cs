using Demo.DAL.INV;
using Demo.DTO.INV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.INV
{
    public class MarcaBL
    {
        private readonly MarcaDAL _marcaDal;

        public MarcaBL()
        {
            _marcaDal = new MarcaDAL();
        }

        public List<MarcaDTO> ObtenerMarcas()
        {
            return _marcaDal.ObtenerMarcas();
        }

        public List<MarcaDTO> ObtenerMarcasConFiltro(string filtro)
        {
            return _marcaDal.ObtenerMarcasConFiltro(filtro);
        }

        public void GuardarMarca(string descripcion, DateTime fechaCreacion, string usuarioCrea, bool estado)
        {
            var marca = new MarcaDTO
            {
                Descripcion = descripcion,
                FechaCreacion = fechaCreacion,
                UsuarioCrea= usuarioCrea,
                Estado = estado
            };

            _marcaDal.InsertarMarca(marca);
        }

        public MarcaDTO ObtenerMarcaPorId(int id)
        {
            return _marcaDal.ObtenerMarcaPorId(id);
        }

        public void ActualizarMarca(MarcaDTO marca)
        {
            _marcaDal.ActualizarMarca(marca);
        }

        public void EliminarMarca(int id)
        {
            _marcaDal.EliminarMarca(id);
        }
    }
}
