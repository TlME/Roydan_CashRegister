using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.DTO;

namespace CashRegister.Persistence
{
    public class TransactionRepo
    {
        public static void AddTransactionItem(InventoryDTO item_DTO, Guid Customer_ID)
        {
            var db = new CashRegisterDbEntities();
            var item = convertToTransactionEntity(item_DTO, Customer_ID);

            db.Transactions.Add(item);
            db.SaveChanges();
        }
        public static List<TransactionDTO> GetTransactions()
        {
            var db = new CashRegisterDbEntities();
            var transaction = db.Transactions.ToList();
            var transaction_DTOs = new List<TransactionDTO>();

            foreach (var item in transaction)
            {
                var nextDTO = convertToTransactionDTO(item);
                transaction_DTOs.Add(nextDTO);
            }
            return transaction_DTOs;
        }
        private static Transaction convertToTransactionEntity(InventoryDTO item_DTO, Guid Customer_ID)
        {
            var transaction = new Transaction();
            transaction.Customer_ID = Customer_ID;
            transaction.Item = item_DTO.ItemID;
            transaction.Price = item_DTO.Price;
            transaction.Time = DateTime.Now;

            return transaction;
        }
        private static TransactionDTO convertToTransactionDTO(Transaction transaction)
        {
            var transaction_DTO = new TransactionDTO();

            transaction_DTO.Item = transaction.Item;
            transaction_DTO.Price = transaction.Price;
            transaction_DTO.Time = transaction.Time;

            return transaction_DTO;
        }
    }
}
