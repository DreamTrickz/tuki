using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DTO.INV
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; }=string.Empty;
        public string Descripcion { get; set; }=string.Empty;
        public int MarcaId { get; set; }
        public int CategoriaId { get; set; }
        public int SubcategoriaId { get; set; }
        public int UnidadMedidaId { get; set; }
        public int StockGeneral {  get; set; }
        public decimal Costo {  get; set; }
        public decimal Precio {  get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCrea {  get; set; }=string.Empty;                
        public bool Estado {  get; set; }=false;

        // Campos opcionales (nullable)
        public DateTime? FechaModificacion { get; set; }  // Fecha puede ser nula
        public string? UsuarioModifica { get; set; }  // Usuario puede ser nulo

        // Relaciones
        public MarcaDTO? Marca { get; set; }
        public CategoriaDTO? Categoria { get; set; }
        public SubcategoriaDTO? Subcategoria { get; set; }
        public UnidadMedidaDTO? UnidadMedida { get; set; }
    }
}
