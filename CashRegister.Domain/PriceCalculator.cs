using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Domain
{
    public class PriceCalculator
    {
        public static string GetPrice(List<DTO.InventoryDTO> currentCart)
        {
            var priceText = "$0.00";
            if (currentCart.Count >= 1)
            {
                priceText = CalcPrice(currentCart).ToString("C");
            } 
            return priceText;
        }
        public static decimal CalcPrice(List<DTO.InventoryDTO> currentCart)
        {
            decimal taxed = 0;
            decimal untaxed = 0;
            foreach (var item in currentCart)
            {
                if (item.TaxExempt)
                {
                    untaxed += item.Price;
                }
                else
                {
                    taxed += item.Price;
                }
            }
            taxed = taxed * 1.05m;
            return taxed + untaxed;
        }

        public static string GetChange(string tender, string totalPrice)
        {
            try
            {
                decimal tendered = Decimal.Parse(tender.Trim('$'));
                decimal total = Decimal.Parse(totalPrice.Remove(0, 27));
                return CalcChange(tendered, total);
            }
            catch (FormatException)
            {
                return "You have entered an erroneous value" + "totalprice: " + totalPrice.Remove(0, 26) + " tendered: " + tender.Trim('$');
            }
        }
        public static string CalcChange(decimal tender, decimal total)
        {
            string changeOwed = "";
            decimal diff = tender - total;
            
            if (Math.Floor(diff / 20.00m) > 0)
            {
                changeOwed += Math.Floor(diff / 20.00m).ToString() + " twenties, ";
                diff = diff % 20.00m;
            }
            if (Math.Floor(diff / 10.00m) > 0)
            {
                changeOwed += Math.Floor(diff / 10.00m).ToString() + " tens, ";
                diff = diff % 10.00m;
            }
            if (Math.Floor(diff / 5.00m) > 0)
            {
                changeOwed += Math.Floor(diff / 5.00m).ToString() + " fives, ";
                diff = diff % 5.00m;
            }
            if (Math.Floor(diff / 1.00m) > 0)
            {
                changeOwed += Math.Floor(diff / 1.00m).ToString() + " ones, ";
                diff = diff % 1.00m;
            }
            if (Math.Floor(diff / 0.25m) > 0)
            {
                changeOwed += Math.Floor(diff / 0.25m).ToString() + " quarters, ";
                diff = diff % 0.25m;
            }
            if (Math.Floor(diff / 0.10m) > 0)
            {
                changeOwed += Math.Floor(diff / 0.10m).ToString() + " dimes, ";
                diff = diff % 0.10m;
            }
            if (Math.Floor(diff / 0.05m) > 0)
            {
                changeOwed += Math.Floor(diff / 0.05m).ToString() + " nickles, ";
                diff = diff % 0.05m;
            }
            if (diff / 0.01m >= 0)
            {
                changeOwed += Math.Floor(diff / 0.01m).ToString() + " pennies, ";
            }
            return changeOwed;
        }
    }
}
