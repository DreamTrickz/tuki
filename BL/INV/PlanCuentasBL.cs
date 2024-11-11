using Demo.DAL.INV;
using Demo.DTO.INV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.INV
{
    public class PlanCuentasBL
    {
        private readonly PlanCuentasDAL _planCuentasDal;

        public PlanCuentasBL()
        {
            _planCuentasDal = new PlanCuentasDAL();
        }

        public List<PlanCuentasDTO> ObtenerPlanCuentass()
        {
            return _planCuentasDal.ObtenerPlanCuentass();
        }

        public List<PlanCuentasDTO> ObtenerPlanCuentassConFiltro(string filtro)
        {
            return _planCuentasDal.ObtenerPlanCuentassConFiltro(filtro);
        }

        public void GuardarPlanCuentas(string nombreCuenta, DateTime fechaCreacion, string usuarioCrea, bool estado)
        {
            var planCuentas = new PlanCuentasDTO
            {
                NombreCuenta = nombreCuenta,
                FechaCreacion = fechaCreacion,
                UsuarioCrea= usuarioCrea,
                Estado = estado
            };

            _planCuentasDal.InsertarPlanCuentas(planCuentas);
        }

        public PlanCuentasDTO ObtenerPlanCuentasPorId(int id)
        {
            return _planCuentasDal.ObtenerPlanCuentasPorId(id);
        }

        public void ActualizarPlanCuentas(PlanCuentasDTO planCuentas)
        {
            _planCuentasDal.ActualizarPlanCuentas(planCuentas);
        }

        public void EliminarPlanCuentas(int id)
        {
            _planCuentasDal.EliminarPlanCuentas(id);
        }
    }
}
