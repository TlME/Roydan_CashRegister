using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.DTO
{
    public class TransactionDTO
    {
        public System.Guid Customer_ID { get; set; }
        public System.Guid Item { get; set; }
        public decimal Price { get; set; }
        public System.DateTime Time { get; set; }
    }
}
