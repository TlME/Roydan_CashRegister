using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CashRegister.Presentation
{
    public partial class Default : System.Web.UI.Page
    {
        // Thoughts: # Move items from the cart table to transactions table
        // #if a transaction is completed successfully. Otherwise move them back to the inventory table. Cart table needs to be functionally identical to inventory. 
        // TODO: #add price calculator, #add textboxes to create new inventory #(make addInventorybutton functional) and #cash tendered, add change calculator, #clean up legacy code, test on lappy.
        // #make page update when new inventory is added, #fix change calc

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                changeOwedPanel.Visible = false;
                loadInventory();
                UpdateCart();

            }
        }
        protected void loadInventory()
        {
            var currentInventory = Domain.InventoryManager.LoadInventory();
            InventoryDDL.DataSource = currentInventory;
            InventoryDDL.DataTextField = "Name";
            InventoryDDL.DataBind();

        }
        protected void addToCart_Button_Click(object sender, EventArgs e)
        {
            CashRegister.DTO.InventoryDTO item_DTO = new DTO.InventoryDTO();
            item_DTO = Domain.InventoryManager.LoadInventory()[InventoryDDL.SelectedIndex];
            Domain.InventoryManager.RemoveInventory(item_DTO);
            Domain.CartManager.AddCartItem(item_DTO);

            UpdateCart();
            loadInventory();
        }
        protected void UpdateCart()
        {
            var currentCart = Domain.CartManager.LoadCartItems();
            string cartText = "";
            foreach (var item in currentCart)
            {
                cartText += "<p>" + item.Name + "   |   " + item.Price.ToString("C") + "</p>";
            }
            userCart.Text = cartText;
            userTotal.Text = "Current Total (with Tax): " + Domain.PriceCalculator.GetPrice(currentCart);
        }
        protected void cancelTransaction_Button_Click(object sender, EventArgs e)
        {
            Domain.TransactionManager.CancelTransaction();
            UpdateCart();
            loadInventory();
        }
        protected void checkout_Button_Click(object sender, EventArgs e)
        {
            showChangeOwed();
            Domain.TransactionManager.ConfirmTransaction();
            UpdateCart();
            loadInventory();
        }
        protected void showChangeOwed()
        {
            changeOwedPanel.Visible = true;
            changeOwedLabel.Text = "Change owed: " + Domain.PriceCalculator.GetChange(cashTenderedTextBox.Text, userTotal.Text);

        }
        protected void addInventoryButton_Click(object sender, EventArgs e)
        {
            CashRegister.DTO.InventoryDTO item_DTO = new DTO.InventoryDTO();

            item_DTO.ItemID = Guid.NewGuid();
            item_DTO.Name = itemNameTextBox.Text;
            item_DTO.Price = Decimal.Parse(itemPriceTextBox.Text);
            item_DTO.TaxExempt = taxExemptCheckbox.Checked;

            Domain.InventoryManager.AddInventory(item_DTO);
            loadInventory();
        }
    }
}