using Demo.DTO.INV;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.INV
{
    public class UnidadMedidaDAL
    {
        private readonly UnidadMedidaDbContext _context;

        public UnidadMedidaDAL()
        {
            _context = new UnidadMedidaDbContext();
        }

        public List<UnidadMedidaDTO> ObtenerUnidadMedidas()
        {
            return _context.UnidadMedidas
                .Select(i => new UnidadMedidaDTO
                {
                    Id = i.Id,
                    Descripcion = i.Descripcion,
                    FechaCreacion = i.FechaCreacion ?? null,
                    UsuarioCrea = i.UsuarioCrea ?? null,
                    Siglas = i.Siglas,
                    // Manejo de campos opcionales
                    FechaModificacion = i.FechaModificacion ?? null,
                    UsuarioModifica = i.UsuarioModifica ?? null,
                    Estado = i.Estado
                })
                .ToList();
        }

        public List<UnidadMedidaDTO> ObtenerUnidadMedidasConFiltro(string filtro)
        {
            using (var context = new UnidadMedidaDbContext())
            {
                var unidadmedidasFiltradas = context.UnidadMedidas
                    .Where(s => s.Descripcion.Contains(filtro))
                    .ToList();
                return unidadmedidasFiltradas;
            }

        }

        public void InsertarUnidadMedida(UnidadMedidaDTO unidadmedida)  
        {
            _context.UnidadMedidas.Add(unidadmedida);
            _context.SaveChanges();
        }

        public UnidadMedidaDTO ObtenerUnidadMedidaPorId(int id)
        {
            var UnidadMedida = _context.UnidadMedidas.FirstOrDefault(m => m.Id == id);

            if (UnidadMedida == null)
            {
                // Maneja el caso en el que no se encuentra la UnidadMedida
                throw new Exception($"No se encontró ninguna UnidadMedida con el ID {id}");
            }
            return UnidadMedida;
        }

        public void ActualizarUnidadMedida(UnidadMedidaDTO UnidadMedida)
        {
            //_context.UnidadMedidas.Update(UnidadMedida);
            //_context.SaveChanges();
            var entidadExistente = _context.UnidadMedidas.FirstOrDefault(e => e.Id == UnidadMedida.Id);

            if (entidadExistente != null)
            {
                UnidadMedida.FechaCreacion = entidadExistente.FechaCreacion;
                _context.Entry(entidadExistente).State = EntityState.Detached; // Desadjuntar la entidad
            }
            _context.Entry(UnidadMedida).State = EntityState.Modified;
            _context.SaveChanges();
        }


        public void EliminarUnidadMedida(int id)
        {
            var UnidadMedida = _context.UnidadMedidas.FirstOrDefault(m => m.Id == id);
            if (UnidadMedida != null)
            {
                _context.UnidadMedidas.Remove(UnidadMedida);
                _context.SaveChanges();
            }
        }
    }
}
