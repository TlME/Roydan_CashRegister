using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Persistence
{
    public class InventoryRepo
    {
        public static void AddInventoryItem()
        {
            var db = new CashRegisterDbEntities();
            var item = new Inventory();

            item.ItemID = Guid.NewGuid();
            item.Name = "Hammer";
            item.Price = 7.45M;
            item.TaxExempt = false;

            db.Inventories.Add(item);
            db.SaveChanges();
        }
    }
}
