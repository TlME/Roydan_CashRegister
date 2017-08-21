using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.DTO;

namespace CashRegister.Persistence
{
    public class ShoppingCartRepo
    {
        public static void AddCartItem(InventoryDTO item_DTO)
        {
            var db = new CashRegisterDbEntities();
            var item = convertToShoppingCartEntity(item_DTO);

            db.ShoppingCarts.Add(item);
            db.SaveChanges();
        }

        public static void RemoveCartItem(InventoryDTO item_DTO)
        {
            var db = new CashRegisterDbEntities();
            var item = convertToShoppingCartEntity(item_DTO);

            db.ShoppingCarts.Attach(item);
            db.ShoppingCarts.Remove(item);
            db.SaveChanges();
        }
        public static List<InventoryDTO> LoadCartItems()
        {
            var db = new CashRegisterDbEntities();
            var cart = db.ShoppingCarts.ToList();
            var inventory_DTOs = new List<InventoryDTO>();

            foreach (var item in cart)
            {
                var nextDTO = convertToInventoryDTO(item);
                inventory_DTOs.Add(nextDTO);
            }
            return inventory_DTOs;
        }
        private static ShoppingCart convertToShoppingCartEntity(InventoryDTO item_DTO)
        {
            var item = new ShoppingCart();

            item.ItemID = item_DTO.ItemID;
            item.Name = item_DTO.Name;
            item.Price = item_DTO.Price;
            item.TaxExempt = item_DTO.TaxExempt;


            return item;
        }
        private static InventoryDTO convertToInventoryDTO(ShoppingCart item)
        {
            var item_DTO = new InventoryDTO();

            item_DTO.ItemID = item.ItemID;
            item_DTO.Name = item.Name;
            item_DTO.Price = item.Price;
            item_DTO.TaxExempt = item.TaxExempt;

            return item_DTO;
        }
    }
}
