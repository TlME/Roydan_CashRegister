using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Domain
{
    public class TransactionManager
    {
        public static void CancelTransaction()
        {
            var currentCart = CartManager.LoadCartItems();
            foreach (var item in currentCart)
            {
                Persistence.InventoryRepo.AddInventoryItem(item);
                Persistence.ShoppingCartRepo.RemoveCartItem(item);
            }
        }
        public static void ConfirmTransaction()
        {
            var currentCart = CartManager.LoadCartItems();
            var custID = Guid.NewGuid();
            foreach (var item in currentCart)
            {
                Persistence.TransactionRepo.AddTransactionItem(item, custID);
                Persistence.ShoppingCartRepo.RemoveCartItem(item);
            }
        }
        public static List<DTO.TransactionDTO> GetTransactions()
        {
            return Persistence.TransactionRepo.GetTransactions();
        }
    }
}
