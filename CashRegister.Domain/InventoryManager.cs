﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Domain
{
    public class InventoryManager
    {
        public static void AddInventory()
        {
            Persistence.InventoryRepo.AddInventoryItem();
        }
    }
}