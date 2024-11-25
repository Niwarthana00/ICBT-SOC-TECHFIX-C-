<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="techfix.Cart" %>
<%@ Register Src="~/NavBar.ascx" TagPrefix="uc" TagName="NavBar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Shopping Cart</title>
    <link href="css/styles.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons/font/bootstrap-icons.css" rel="stylesheet">
    <style>
        body {
            background-color: #101010;
        }
        .cart-item {
            background-color: #212529;
            border-radius: 8px;
            padding: 15px;
            margin-bottom: 15px;
            color: white;
            width: 1038px;
            margin-left: 139px;
        }
        .cart-item img {
            max-width: 100px;
            height: 100px;
        }
        .total-price {
            font-size: 1.2em;
            font-weight: bold;
        }
        .btn {
            background-color: #04861c;
            color: white;
            border-radius: 0;
            padding: 10px 10px 10px 10px;
            margin-left: 32px;
            margin-bottom: 20px;
            width: 170px;
        }
        .remove-btn {
            color: red;
            cursor: pointer;
        }
        .empty-text {
            margin-top: 100px;
        }
        .download-btn {
            background-color: #e13911;
            color: white;
            border-radius: 0;
            padding: 10px 10px 10px 10px;
            margin-left: 32px;
            margin-bottom: 20px;
            margin-right: 123px;
        }
    </style>
</head>
<body>

<form id="form1" runat="server">
    <div class="container mt-5">
        <h1 class="text-center text-white mb-4">Shopping Cart</h1>
        <asp:ListView ID="lvCartItems" runat="server">
            <ItemTemplate>
                <div class="row cart-item align-items-center">
                    <div class="col-3 col-md-2">
                        <img src='<%# Eval("Image") %>' alt='<%# Eval("ItemName") %>' class="img-fluid rounded" />
                    </div>
                    <div class="col-4 col-md-3">
                        <h5 class="mb-0"><%# Eval("ItemName") %></h5>
                    </div>
                    <div class="col-2 col-md-2 text-center">
                        <p class="mb-0">Quantity: <%# Eval("Quantity") %></p>
                    </div>
                    <div class="col-2 col-md-2 text-center">
                        <p class="mb-0">Price: RS.<%# Eval("Price", "{0:0.00}") %></p>
                    </div>
                    <div class="col-2 col-md-2 text-center">
                        <p class="total-price mb-0">Total: RS.<%# Eval("TotalPrice", "{0:0.00}") %></p>
                    </div>
                    <div class="col-1 col-md-1 text-center">
                        <asp:LinkButton ID="btnRemove" runat="server" OnClick="RemoveItem_Click" CssClass="remove-btn" CommandArgument='<%# Eval("ItemName") %>'>
                            <i class="bi bi-trash-fill"></i>
                        </asp:LinkButton>
                    </div>
                </div>
                <hr class="bg-white" />
            </ItemTemplate>
        </asp:ListView>

        <div class="d-flex justify-content-between align-items-center mt-4">
            <h3 class="text-white" style="margin-left: 143px;">
                Grand Total: 
                RS.<asp:Label ID="grandTotalLabel" runat="server" Text="0.00"></asp:Label>
            </h3>

           <div>
            <asp:Button ID="Button1" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="back_Click" />
         </div>

            <div>
                <asp:Button ID="btnCheckout" runat="server" Text="Checkout" CssClass="btn btn-primary" OnClick="Checkout_Click" />
                <asp:Button ID="btnDownloadQuotation" runat="server" Text="Download the Quotation" CssClass="btn download-btn" OnClick="DownloadQuotation_Click" />
            </div>
        </div>
    </div>
</form>

<script src = "https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
