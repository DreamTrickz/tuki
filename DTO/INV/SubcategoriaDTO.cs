using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DTO.INV
{
    public class SubcategoriaDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }=string.Empty;
        public int CategoriaId { get; set; }
        public bool Estado { get; set; } = false;

        // Propiedad de navegación para CategoriaDTO
        public CategoriaDTO? Categoria { get; set; } 
    }
}
