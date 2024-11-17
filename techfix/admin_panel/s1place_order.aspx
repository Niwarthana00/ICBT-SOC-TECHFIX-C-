<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="s1place_order.aspx.cs" Inherits="techfix.admin_panel.s1place_order" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Place Order</title>
    <link href="css/place.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Sidebar ID="Sidebar" runat="server" />

        <div class="checkout-container">
            <h2>Checkout Details</h2>
            <div class="form-group">
                <label for="NameTextBox" class="form-label">Name:</label>
                <asp:TextBox ID="NameTextBox" CssClass="form-control" runat="server" placeholder="Enter your name" />
            </div>
            
            <div class="form-group">
                <label for="NumberTextBox" class="form-label">Phone Number:</label>
                <asp:TextBox ID="NumberTextBox" CssClass="form-control" runat="server"  placeholder="Enter phone number"/>
            </div>

            <h2>Card Details</h2>
            <div class="card-details-container">
                <div class="form-group card-input">
                    <label for="CardNumberTextBox" class="form-label">Card Number:</label>
                    <div class="input-icon-wrapper">
                        <asp:TextBox ID="CardNumberTextBox" CssClass="form-control" runat="server" placeholder="1234 5678 9101 1121" />
                        <span class="card-icon">
                            <img src="img/card.png" alt="Card Icon" />
                        </span>
                    </div>
                </div>

                <div class="form-group card-expiry">
                    <label for="ExpiryDateTextBox" class="form-label">Expiry Date (MM/YY):</label>
                    <asp:TextBox ID="ExpiryDateTextBox" CssClass="form-control" runat="server" placeholder="MM/YY" />
                </div>

                <div class="form-group card-cvv">
                    <label for="CVVTextBox" class="form-label">CVV:</label>
                    <asp:TextBox ID="CVVTextBox" CssClass="form-control" TextMode="Password" runat="server" placeholder="123" />
                </div>
            </div>

            <asp:Button ID="PayNowButton" CssClass="btn btn-primary" runat="server" Text="Pay Now" OnClick="PayNowButton_Click" />
        </div>
    </form>
</body>
</html>
