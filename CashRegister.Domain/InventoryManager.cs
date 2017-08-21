using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Domain
{
    public class InventoryManager
    {
        public static void AddInventory(DTO.InventoryDTO item_DTO)
        {
            Persistence.InventoryRepo.AddInventoryItem(item_DTO);
        }

        public static void RemoveInventory(DTO.InventoryDTO item_DTO)
        {
            Persistence.InventoryRepo.RemoveInventoryItem(item_DTO);
        }

        public static List<DTO.InventoryDTO> LoadInventory()
        {
            return Persistence.InventoryRepo.LoadInventory();
        }
    }
}
