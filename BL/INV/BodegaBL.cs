using Demo.DAL.INV;
using Demo.DTO.INV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.INV
{
    public class BodegaBL
    {
        private readonly BodegaDAL _bodegaDal;

        public BodegaBL()
        {
            _bodegaDal = new BodegaDAL();
        }

        public List<BodegaDTO> ObtenerBodegas()
        {
            return _bodegaDal.ObtenerBodegas();
        }

        public List<BodegaDTO> ObtenerBodegasConFiltro(string filtro)
        {
            return _bodegaDal.ObtenerBodegasConFiltro(filtro);
        }

        public void GuardarBodega(string codigo, string descripcion, DateTime fechaCreacion, string usuarioCrea, bool estado)
        {
            var bodega = new BodegaDTO
            {
                Codigo = codigo,
                Descripcion = descripcion,
                FechaCreacion = fechaCreacion,
                UsuarioCrea = usuarioCrea,
                Estado = estado
            };

            _bodegaDal.InsertarBodega(bodega);
        }

        public BodegaDTO ObtenerBodegaPorId(int id)
        {
            return _bodegaDal.ObtenerBodegaPorId(id);
        }

        public void ActualizarBodega(BodegaDTO bodega)
        {
            _bodegaDal.ActualizarBodega(bodega);
        }

        public void EliminarBodega(int id)
        {
            _bodegaDal.EliminarBodega(id);
        }
    }
}
