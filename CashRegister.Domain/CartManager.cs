using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Domain
{
    public class CartManager
    {
        public static void AddCartItem(DTO.InventoryDTO item_DTO)
        {
            Persistence.ShoppingCartRepo.AddCartItem(item_DTO);
        }

        public static void RemoveCartItem(DTO.InventoryDTO item_DTO)
        {
            Persistence.ShoppingCartRepo.RemoveCartItem(item_DTO);
        }

        public static List<DTO.InventoryDTO> LoadCartItems()
        {
            return Persistence.ShoppingCartRepo.LoadCartItems();
        }
    }
}
