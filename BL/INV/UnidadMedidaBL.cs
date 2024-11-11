using Demo.DAL.INV;
using Demo.DTO.INV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.INV
{
    public class UnidadMedidaBL
    {
        private readonly UnidadMedidaDAL _unidadmedidaDal;

        public UnidadMedidaBL()
        {
            _unidadmedidaDal = new UnidadMedidaDAL();
        }

        public List<UnidadMedidaDTO> ObtenerUnidadMedidas()
        {
            return _unidadmedidaDal.ObtenerUnidadMedidas();
        }

        public List<UnidadMedidaDTO> ObtenerUnidadMedidasConFiltro(string filtro)
        {
            return _unidadmedidaDal.ObtenerUnidadMedidasConFiltro(filtro);
        }

        public void GuardarUnidadMedida(string descripcion, string siglas, DateTime fechaCreacion, string usuarioCrea, bool estado)
        {
            var UnidadMedida = new UnidadMedidaDTO
            {
                Siglas = siglas,
                Descripcion = descripcion,
                FechaCreacion = fechaCreacion,
                UsuarioCrea = usuarioCrea,
                Estado = estado
            };

            _unidadmedidaDal.InsertarUnidadMedida(UnidadMedida);
        }

        public UnidadMedidaDTO ObtenerUnidadMedidaPorId(int id)
        {
            return _unidadmedidaDal.ObtenerUnidadMedidaPorId(id);
        }

        public void ActualizarUnidadMedida(UnidadMedidaDTO UnidadMedida)
        {
            _unidadmedidaDal.ActualizarUnidadMedida(UnidadMedida);
        }

        public void EliminarUnidadMedida(int id)
        {
            _unidadmedidaDal.EliminarUnidadMedida(id);
        }
    }
}