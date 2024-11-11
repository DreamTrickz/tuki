using Demo.DAL.INV;
using Demo.DTO.INV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.INV
{
    public class ItemBL
    {
        private readonly ItemDAL _itemDal;

        public ItemBL()
        {
            _itemDal = new ItemDAL();
        }

        // Método para obtener todos los ítems
        public List<ItemDTO> ObtenerItems()
        {
            return _itemDal.ObtenerItems();
        }

        // Método para agregar un ítem
        public void AgregarItem(ItemDTO item)
        {
            _itemDal.AgregarItem(item);
        }

        // Método para actualizar un ítem
        public void ActualizarItem(ItemDTO item)
        {
            _itemDal.ActualizarItem(item);
        }

        // Método para eliminar un ítem
        public void EliminarItem(int id)
        {
            _itemDal.EliminarItem(id);
        }
        
        // Método para obtener un ítem por su ID
        public ItemDTO ObtenerItemPorId(int id)
        {
            var item = _itemDal.ObtenerItemPorId(id);

            if (item == null)
            {
                // Puedes lanzar una excepción si no se encuentra el ítem
                throw new InvalidOperationException("El ítem con el ID proporcionado no fue encontrado.");
            }

            return item;
        }        
    }
}
