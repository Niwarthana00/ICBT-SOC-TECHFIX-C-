<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="supplier1_order.aspx.cs" Inherits="techfix.admin_panel.supplier1_order" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Supplier Categories</title>
    <style>
        /* Dark theme styling */
        body {
            background-color: #121212;
            color: white;
            font-family: Arial, sans-serif;
        }
        .tabs {
            margin-bottom: 45px;
            margin-top: 35px;
            margin-left: -608px;
        }
        .tabs a {
            display: inline-block;
            padding: 10px 20px;
            background-color: #1f1f1f;
            color: white;
            margin-right: 5px;
            text-decoration: none;
            border-radius: 4px;
        }
        .btn-primary{
            color: #fff !important;
            background-color: #FF3333 !important;
            border-color: #FF3333 !important;
            margin-top: 15px !important;
            width: 195px !important;
            margin-left: -20px !important;
            border-radius: 0px !important;
            font-weight: bold !important;
            font-size: 20px !important;
        }

        .select-pr{
            color: white;
            margin-left: -100px;
            margin-bottom: 21px;
        }

        .tabs a:hover, .tabs a.active {
            background-color: #333333;
        }
        .product-list {
            display: flex;
            flex-wrap: wrap;
            gap: 20px;
            width: 1253px;
            margin-left: -607px;
        }
        .product {
            display: flex;
            flex-direction: row;
            align-items: center;
            justify-content: space-between;
            margin-bottom: 20px;
            padding: 10px;
            background-color: #1f1f1f;
            border-radius: 8px;
            width: 48%;
            box-sizing: border-box;
        }
        .product img {
            max-width: 100px;
            margin-right: 40px;
            margin-left: 41px;
        }
        .product-details {
            flex-grow: 1;
        }
        .product-actions {
            text-align: right;
        }
        .qty-buttons {
            margin-top: 10px;
        }
        .qty-buttons button {
            background-color: #333333;
            color: white;
            padding: 5px;
            border: none;
            margin-left: 5px;
        }
        /* Section for displaying selected items */
        #selectedItems {
            margin-top: 30px;
        }
        .selected-item {
            display: flex;
            justify-content: space-between;
            margin-bottom: 15px;
            padding: 15px;
            background-color: #9e4141;
            border-radius: 3px;
            margin-left: -352px;
            margin-right: 221px;
            color: white;
        }
        .selected-item span {
            display: inline-block;
            margin-right: 20px;
        }
        .total-price {
            font-weight: bold;
            margin-top: 20px;
            color: white;
            font-size: 20px;
            margin-left: -18px;
        }

        .new-btn {
            color: #fff !important;
            background-color: #FF3333 !important;
            border-color: #FF3333 !important;
            margin-top: 15px !important;
            width: 195px !important;
            margin-left: -20px !important;
            border-radius: 0px !important;
            font-weight: bold !important;
            font-size: 20px !important;
            color: white;
            margin-right: 142px !important;
            margin-left: -219px !important; 
            margin-top: 10px !important;
            height: 44px;
        }

                 
        
    </style>
</head>
<body>
    <uc1:Sidebar ID="Sidebar" runat="server" />
    <form id="form1" runat="server">
        <!-- Category Tabs -->
        <div class="tabs">
            <asp:Repeater ID="RepeaterCategories" runat="server">
                <ItemTemplate>
                    <asp:LinkButton ID="CategoryTab" runat="server" Text='<%# Eval("category_name") %>' CommandArgument='<%# Eval("id") %>' OnClick="CategoryTab_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <!-- Products Section -->
        <div class="product-list">
            <asp:Repeater ID="RepeaterProducts" runat="server">
                <ItemTemplate>
                    <div class="product">
                        <img src='<%# ResolveUrl("" + Eval("image")) %>' alt="Product Image" />
                        <div class="product-details">
                            <h3><asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("product_name") %>' /></h3>
                            <p>Price: $<asp:Label ID="ProductPriceLabel" runat="server" Text='<%# Eval("price") %>' /></p>
                            <p><%# GetStockStatus(Eval("qty")) %></p>
                        </div>
                        <div class="product-actions">
                            <asp:HiddenField ID="HiddenProductId" runat="server" Value='<%# Eval("id") %>' />
                            <asp:CheckBox ID="SelectProductCheckbox" runat="server" OnCheckedChanged="SelectProductCheckbox_CheckedChanged" AutoPostBack="true" />
                            <div class="qty-buttons">
                                <asp:Button ID="DecreaseQty" runat="server" Text="-" CommandArgument='<%# Eval("id") %>' OnClick="DecreaseQty_Click" />
                                <asp:Label ID="ProductQtyLabel" runat="server" Text="1" />
                                <asp:Button ID="IncreaseQty" runat="server" Text="+" CommandArgument='<%# Eval("id") %>' OnClick="IncreaseQty_Click" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <!-- Selected Items Section -->
        
        <div id="selectedItems">
            <h3 class="select-pr">Selected Products:</h3>
            <asp:Repeater ID="RepeaterSelectedProducts" runat="server">
                <ItemTemplate>
                    <div class="selected-item">
                        <span><%# Eval("ProductName") %> - $<%# Eval("Price") %> x <%# Eval("Quantity") %> = $<%# Eval("TotalPrice") %></span>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="total-price">
                Total Price: $<asp:Label ID="TotalPriceLabel" runat="server" Text="0" />
            </div>


             <asp:Button ID="PlaceOrderButton" runat="server" Text="Place Order" CssClass="new-btn" OnClick="PlaceOrderButton_Click" />
            <asp:Button ID="AddToQuoteButton" runat="server" Text="Add to Quote" OnClick="AddToQuoteButton_Click" CssClass="btn btn-primary" />
        </div>

    </form>
</body>
</html>
