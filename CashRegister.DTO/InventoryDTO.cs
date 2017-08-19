using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.DTO
{
    public class InventoryDTO
    {
        public System.Guid ItemID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool TaxExempt { get; set; }
    }
}
