<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="s2quote.aspx.cs" Inherits="techfix.admin_panel.s2quote" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quote</title>
    <style>
        body {
            background-color: #121212;
            color: white;
            font-family: Arial, sans-serif;
        }
        .quote-list {
            margin: 20px;
        }
        .selected-item {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 15px;
            padding: 28px;
            background-color: #302f2f;
            border-radius: 3px;
            color: white;
            margin-left: -781px;
            margin-right: 100px;
        }
        .headdinh-h3 {
            margin-bottom: 47px;
            margin-top: 34px;
            margin-left: -401px;
        }
        
        .total-price {
            font-weight: bold;
            margin-top: 20px;
            color: white;
            font-size: 29px;

        }

        
        .remove-icon {
            color: red;
            cursor: pointer;
            font-size: 20px;
        }
        .download-button {
            margin: 20px;
            padding: 10px 62px;
            background-color: #FF3333;
            color: white;
            border: none;
            border-radius: 0px;
            cursor: pointer;
        }
        .back{
            margin: 20px;
            padding: 10px 62px;
            background-color: #FF3333;
            color: white;
            border: none;
            border-radius: 0px;
            cursor: pointer;
            margin-left: 21px;
            width: 246px;

        }
    </style>
</head>
<body>
    <uc1:Sidebar ID="Sidebar" runat="server" />
    <form id="form1" runat="server">
        <div class="quote-list">
            <h3 class="headdinh-h3">Quote Details:</h3>
            <asp:Repeater ID="RepeaterQuoteItems" runat="server">
                <ItemTemplate>
                    <div class="selected-item">
                        <span><%# Eval("ProductName") %> - $<%# Eval("Price") %> x <%# Eval("Quantity") %> = $<%# Eval("TotalPrice") %></span>
                        <span class="remove-icon" onclick="removeItem('<%# Eval("ProductId") %>')">&#x1F5D1;</span> <!-- Red bin icon -->
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div class="total-price">
                Total Price: $<asp:Label ID="TotalPriceLabel" runat="server" Text="0" />
            </div>
            <button type="button" class="back" onclick="location.href='supplier2_order.aspx'">Back</button>
            <asp:Button ID="DownloadQuoteButton" runat="server" Text="Download Quote" CssClass="download-button" OnClick="DownloadQuoteButton_Click" />
        </div>
    </form>
    <script type="text/javascript">
        function removeItem(productId) {
            __doPostBack('RepeaterQuoteItems', productId); // Trigger the postback to remove item
        }
    </script>
</body>
</html>
