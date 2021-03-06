﻿using System;
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
            var item = convertToInventoryEntity(item_DTO);

            db.Inventories.Add(item);
            db.SaveChanges();
        }

        public static List<InventoryDTO> LoadInventory()
        {
            var db = new CashRegisterDbEntities();
            var inventory = db.Inventories.ToList();
            var inventory_DTOs = new List<InventoryDTO>();

            foreach(var item in inventory)
            {
                var nextDTO = convertToInventoryDTO(item);
                inventory_DTOs.Add(nextDTO);
            }
            return inventory_DTOs;
        }

        public static void RemoveInventoryItem(InventoryDTO item_DTO)
        {
            var db = new CashRegisterDbEntities();
            var item = convertToInventoryEntity(item_DTO);

            db.Inventories.Attach(item);
            db.Inventories.Remove(item);
            db.SaveChanges();
        }

        private static Inventory convertToInventoryEntity(InventoryDTO item_DTO)
        {
            var item = new Inventory();
            
            item.ItemID = item_DTO.ItemID;
            item.Name = item_DTO.Name;
            item.Price = item_DTO.Price;
            item.TaxExempt = item_DTO.TaxExempt;


            return item;
        }
        private static InventoryDTO convertToInventoryDTO(Inventory item)
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
