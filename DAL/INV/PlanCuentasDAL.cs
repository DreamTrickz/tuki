using Demo.DTO.INV;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.INV
{
    public class PlanCuentasDAL
    {

        private readonly PlanCuentasDbContext _context;

        public PlanCuentasDAL()
        {
            _context = new PlanCuentasDbContext();
        }

        public List<PlanCuentasDTO> ObtenerPlanCuentass()
        {
            return _context.PlanCuentass
                .Select(i => new PlanCuentasDTO
                {
                    Id = i.Id,
                    CodigoCuenta = i.CodigoCuenta,
                    NombreCuenta = i.NombreCuenta,
                    TipoCuenta = i.TipoCuenta,
                    FechaCreacion = i.FechaCreacion,
                    UsuarioCrea = i.UsuarioCrea,
                    // Manejo de campos opcionales
                    FechaModificacion = i.FechaModificacion ?? null,
                    UsuarioModifica = i.UsuarioModifica ?? null,
                    Estado = i.Estado
                })                
                .ToList();
        }

        public List<PlanCuentasDTO> ObtenerPlanCuentassConFiltro(string filtro)
        {
            using (var context = new PlanCuentasDbContext())
            {
                var planCuentassFiltradas = context.PlanCuentass                    
                    .Where(s => s.NombreCuenta.Contains(filtro))
                    .ToList();
                return planCuentassFiltradas;
            }

        }

        public void InsertarPlanCuentas(PlanCuentasDTO planCuentas)
        {
            _context.PlanCuentass.Add(planCuentas);
            _context.SaveChanges();
        }

        public PlanCuentasDTO ObtenerPlanCuentasPorId(int id)
        {            
            var planCuentas = _context.PlanCuentass.FirstOrDefault(m => m.Id == id);

            if (planCuentas == null)
            {
                // Maneja el caso en el que no se encuentra la planCuentas
                throw new Exception($"No se encontró ninguna planCuentas con el ID {id}");
            }
            return planCuentas;
        }

        public void ActualizarPlanCuentas(PlanCuentasDTO planCuentas)
        {
            //_context.PlanCuentass.Update(planCuentas);
            //_context.SaveChanges();
            var entidadExistente = _context.PlanCuentass.FirstOrDefault(e => e.Id == planCuentas.Id);

            if (entidadExistente != null)
            {
                planCuentas.FechaCreacion = entidadExistente.FechaCreacion;
                _context.Entry(entidadExistente).State = EntityState.Detached; // Desadjuntar la entidad
            }
            _context.Entry(planCuentas).State = EntityState.Modified;
            _context.SaveChanges();
        }


        public void EliminarPlanCuentas(int id)
        {
            var planCuentas = _context.PlanCuentass.FirstOrDefault(m => m.Id == id);
            if (planCuentas != null)
            {
                _context.PlanCuentass.Remove(planCuentas);
                _context.SaveChanges();
            }
        }
    }
}