using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.DTO;

namespace CashRegister.Persistence
{
    public class InventoryRepo
    {
        public static void AddInventoryItem(DTO.InventoryDTO item_DTO)
        {
            var db = new CashRegisterDbEntities();
            var item = convertToEntity(item_DTO);

            db.Inventories.Add(item);
            db.SaveChanges();
        }

        private static Inventory convertToEntity(InventoryDTO item_DTO)
        {
            var item = new Inventory();
            item.ItemID = item_DTO.ItemID;
            item.Name = item_DTO.Name;
            item.Price = item_DTO.Price;
            item.TaxExempt = item_DTO.TaxExempt;

            return item;
        }
    }
}
