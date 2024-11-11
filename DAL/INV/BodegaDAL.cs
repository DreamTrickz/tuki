using Demo.DTO.INV;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.INV
{
    public class BodegaDAL
    {
        /*La palabra clave readonly en C# se utiliza para definir un campo 
         * que solo puede ser asignado durante la inicialización de la instancia del objeto, 
         * ya sea en la declaración del campo o en el constructor de la clase. 
         * Una vez que se ha asignado un valor a un campo Bodegado como readonly, 
         * no puede ser modificado posteriormente (excepto en el constructor).
         */

        private readonly BodegaDbContext _context;

        public BodegaDAL()
        {
            _context = new BodegaDbContext();
        }

        /*public List<BodegaDTO> ObtenerBodegas()
        {
            return _context.Bodegas.ToList();
        }*/

        public List<BodegaDTO> ObtenerBodegas()
        {
            return _context.Bodegas
                .Select(i => new BodegaDTO
                {
                    Id = i.Id,
                    Codigo = i.Codigo,
                    Descripcion = i.Descripcion,
                    IdTipoBodega = i.IdTipoBodega,
                    FechaCreacion = i.FechaCreacion,
                    UsuarioCrea = i.UsuarioCrea ?? null,
                    // Manejo de campos opcionales
                    FechaModificacion = i.FechaModificacion ?? null,
                    UsuarioModifica = i.UsuarioModifica ?? null,
                    Estado = i.Estado
                })                
                .ToList();
        }

        public List<BodegaDTO> ObtenerBodegasConFiltro(string filtro)
        {
            using (var context = new BodegaDbContext())
            {
                var bodegasFiltradas = context.Bodegas                    
                    .Where(s => s.Descripcion.Contains(filtro))
                    .ToList();
                return bodegasFiltradas;
            }

        }

        public void InsertarBodega(BodegaDTO bodega)
        {
            _context.Bodegas.Add(bodega);
            _context.SaveChanges();
        }

        public BodegaDTO ObtenerBodegaPorId(int id)
        {            
            var bodega = _context.Bodegas.FirstOrDefault(m => m.Id == id);

            if (bodega == null)
            {
                // Maneja el caso en el que no se encuentra la Bodega
                throw new Exception($"No se encontró ninguna Bodega con el ID {id}");
            }
            return bodega;
        }

        public void ActualizarBodega(BodegaDTO bodega)
        {
            //_context.Bodegas.Update(Bodega);
            //_context.SaveChanges();
            var entidadExistente = _context.Bodegas.FirstOrDefault(e => e.Id == bodega.Id);

            if (entidadExistente != null)
            {
                bodega.FechaCreacion = entidadExistente.FechaCreacion;
                _context.Entry(entidadExistente).State = EntityState.Detached; // Desadjuntar la entidad
            }
            _context.Entry(bodega).State = EntityState.Modified;
            _context.SaveChanges();
        }


        public void EliminarBodega(int id)
        {
            var bodega = _context.Bodegas.FirstOrDefault(m => m.Id == id);
            if (bodega != null)
            {
                _context.Bodegas.Remove(bodega);
                _context.SaveChanges();
            }
        }
    }
}
