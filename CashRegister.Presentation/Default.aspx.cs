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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addInventoryButton_Click(object sender, EventArgs e)
        {
            CashRegister.DTO.InventoryDTO item_DTO = new DTO.InventoryDTO();
         
            item_DTO.ItemID = Guid.NewGuid();
            item_DTO.Name = "Firecrackers 24 pc.";
            item_DTO.Price = 4.97M;
            item_DTO.TaxExempt = false;

            Domain.InventoryManager.AddInventory(item_DTO);
        }
    }
}