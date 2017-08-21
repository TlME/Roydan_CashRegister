<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CashRegister.Presentation.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    
    <form id="form1" runat="server">
    <div class="container">
        <div class="page-header">
            <h2>Roydan General Store</h2>
            <p>Life's little necessities!</p>
        </div>
        <div class="col-lg-6">
            <h3>Checkout</h3>
            <div>
                <asp:DropDownList ID="InventoryDDL" runat="server"></asp:DropDownList>
            </div>
            <div>
                <asp:Button ID="addToCart" Text="Add to cart" runat="server" OnClick="addToCart_Button_Click" />
            </div>
            <div>
                <asp:Label ID="userCart" runat="server"></asp:Label>
            </div>
            <div>
                <asp:Label ID="userTotal" runat="server"></asp:Label>
            </div>
            <div>
                <br />
                <label>Cash Tendered<asp:TextBox ID="cashTenderedTextBox" runat="server" CssClass="form-control"></asp:TextBox></label>
            </div>
            <div>
                <asp:Button ID="cancelTransaction" Text="Cancel Transaction" runat="server" OnClick="cancelTransaction_Button_Click" />
                <asp:Button ID="checkout" Text="Check Out" runat="server" OnClick="checkout_Button_Click" />
            </div>
            <asp:Panel ID="changeOwedPanel" runat="server" >
                <asp:Label ID="changeOwedLabel" runat="server"></asp:Label>
            </asp:Panel>
        </div>
        <div class="col-lg-6">
            <h3>Add Inventory</h3>
            <div class="form-group">
                <label>Item Name:</label>
                <asp:TextBox ID="itemNameTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                <label>Item Price:</label>
                <asp:TextBox ID="itemPriceTextBox" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="checkbox">
                <label><asp:CheckBox ID="taxExemptCheckbox" runat="server" />Tax Exempt</label>
            </div>
            <div>
                <asp:Button ID="addInventoryButton" Text="Add inventory" runat="server" OnClick="addInventoryButton_Click" />
            </div>

        </div>
    </div>
    </form>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</body>
</html>
