using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DTO.INV
{
    public class MarcaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public string? UsuarioCrea { get; set; } = string.Empty;
        
        // Campos opcionales (nullable)
        public DateTime? FechaModificacion { get; set; }  // Fecha puede ser nula
        public string? UsuarioModifica { get; set; }  // Usuario puede ser nulo
        public bool Estado { get; set; } = false;
    }
}
