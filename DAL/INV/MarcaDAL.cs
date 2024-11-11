using Demo.DTO.INV;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.INV
{
    public class MarcaDAL
    {
        /*La palabra clave readonly en C# se utiliza para definir un campo 
         * que solo puede ser asignado durante la inicialización de la instancia del objeto, 
         * ya sea en la declaración del campo o en el constructor de la clase. 
         * Una vez que se ha asignado un valor a un campo marcado como readonly, 
         * no puede ser modificado posteriormente (excepto en el constructor).
         */

        private readonly MarcaDbContext _context;

        public MarcaDAL()
        {
            _context = new MarcaDbContext();
        }

        /*public List<MarcaDTO> ObtenerMarcas()
        {
            return _context.Marcas.ToList();
        }*/

        public List<MarcaDTO> ObtenerMarcas()
        {
            return _context.Marcas
                .Select(i => new MarcaDTO
                {
                    Id = i.Id,
                    Descripcion = i.Descripcion,
                    FechaCreacion = i.FechaCreacion,
                    UsuarioCrea = i.UsuarioCrea ?? null,
                    // Manejo de campos opcionales
                    FechaModificacion = i.FechaModificacion ?? null,
                    UsuarioModifica = i.UsuarioModifica ?? null,
                    Estado = i.Estado
                })                
                .ToList();
        }

        public List<MarcaDTO> ObtenerMarcasConFiltro(string filtro)
        {
            using (var context = new MarcaDbContext())
            {
                var marcasFiltradas = context.Marcas                    
                    .Where(s => s.Descripcion.Contains(filtro))
                    .ToList();
                return marcasFiltradas;
            }

        }

        public void InsertarMarca(MarcaDTO marca)
        {
            _context.Marcas.Add(marca);
            _context.SaveChanges();
        }

        public MarcaDTO ObtenerMarcaPorId(int id)
        {            
            var marca = _context.Marcas.FirstOrDefault(m => m.Id == id);

            if (marca == null)
            {
                // Maneja el caso en el que no se encuentra la marca
                throw new Exception($"No se encontró ninguna marca con el ID {id}");
            }
            return marca;
        }

        public void ActualizarMarca(MarcaDTO marca)
        {
            //_context.Marcas.Update(marca);
            //_context.SaveChanges();
            var entidadExistente = _context.Marcas.FirstOrDefault(e => e.Id == marca.Id);

            if (entidadExistente != null)
            {
                marca.FechaCreacion = entidadExistente.FechaCreacion;
                _context.Entry(entidadExistente).State = EntityState.Detached; // Desadjuntar la entidad
            }
            _context.Entry(marca).State = EntityState.Modified;
            _context.SaveChanges();
        }


        public void EliminarMarca(int id)
        {
            var marca = _context.Marcas.FirstOrDefault(m => m.Id == id);
            if (marca != null)
            {
                _context.Marcas.Remove(marca);
                _context.SaveChanges();
            }
        }
    }
}
