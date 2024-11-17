<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="compare.aspx.cs" Inherits="techfix.admin_panel.compare" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Price Comparison</title>
    <style>
        body {
            background-color: #1e1e1e;
            color: #ffffff;
            font-family: Arial, sans-serif;
        }

        .container {
            text-align: center;
            margin-top: 50px;
            margin-right: 100px !important;
            margin-left: -740px !important;
        }

        .title {
            font-size: 32px;
            margin-bottom: 30px;
        }

        .product-details {
            width: 80%;
            margin: 0 auto;
            border-collapse: collapse;
            color: #ffffff;
        }

        .product-details th, .product-details td {
            padding: 12px;
            border: 1px solid #555;
            text-align: center;
        }

        .search-box {
            width: 80%;
            padding: 10px;
            background-color: #333;
            color: #ffffff;
            border: none;
            outline: none;
            margin-bottom: 25px;
            margin-top: 15px;
        }

        .search-box::placeholder {
            color: #aaa;
        }

        .product-image {
            width: 100px;
            height: auto;
        }

        .buy-now-btn {
            padding: 10px 20px;
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
            margin-top: 10px;
            text-align: center;
            font-size: 16px;
        }

        .buy-now-btn:hover {
            background-color: #45a049;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <uc1:Sidebar ID="Sidebar" runat="server" />
        <div class="container">
            <div class="title">Price Comparison</div>

            <table class="product-details">
                <tr>
                    <th></th>
                    <th>Supplier 1</th>
                    <th>Supplier 2</th>
                </tr>
                <tr>
                    <td>Search</td>
                    <td>
                        <asp:TextBox 
                            ID="Supplier1SearchBox" 
                            CssClass="search-box" 
                            runat="server" 
                            AutoPostBack="true" 
                            OnTextChanged="Supplier1SearchBox_TextChanged" 
                            placeholder="Search Supplier 1..."></asp:TextBox>
                        <asp:AutoCompleteExtender
                            ID="Supplier1AutoCompleteExtender"
                            runat="server"
                            TargetControlID="Supplier1SearchBox"
                            ServiceMethod="GetSupplier1Suggestions"
                            MinimumPrefixLength="1"
                            CompletionSetCount="10"
                            EnableCaching="true">
                        </asp:AutoCompleteExtender>
                        <asp:Image ID="Supplier1Image" runat="server" Width="100px" Height="100px" />
                        <br />
                        <asp:Button ID="Supplier1BuyNowBtn" runat="server" Text="Buy Now" CssClass="buy-now-btn" OnClick="Supplier1BuyNowBtn_Click" />
                    </td>
                    <td>
                        <asp:TextBox 
                            ID="Supplier2SearchBox" 
                            CssClass="search-box" 
                            runat="server" 
                            AutoPostBack="true" 
                            OnTextChanged="Supplier2SearchBox_TextChanged" 
                            placeholder="Search Supplier 2..."></asp:TextBox>
                        <asp:AutoCompleteExtender
                            ID="Supplier2AutoCompleteExtender"
                            runat="server"
                            TargetControlID="Supplier2SearchBox"
                            ServiceMethod="GetSupplier2Suggestions"
                            MinimumPrefixLength="1"
                            CompletionSetCount="10"
                            EnableCaching="true">
                        </asp:AutoCompleteExtender>
                        <asp:Image ID="Supplier2Image" runat="server" Width="100px" Height="100px" />
                        <br />
                        <asp:Button ID="Supplier2BuyNowBtn" runat="server" Text="Buy Now" CssClass="buy-now-btn" OnClick="Supplier2BuyNowBtn_Click" />
                    </td>
                </tr>

                <tr>
                    <td>NAME</td>
                    <td><asp:Label ID="Supplier1Name" runat="server"></asp:Label></td>
                    <td><asp:Label ID="Supplier2Name" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>DESCRIPTION</td>
                    <td><asp:Label ID="Supplier1Description" runat="server"></asp:Label></td>
                    <td><asp:Label ID="Supplier2Description" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>PRICE</td>
                    <td><asp:Label ID="Supplier1Price" runat="server"></asp:Label></td>
                    <td><asp:Label ID="Supplier2Price" runat="server"></asp:Label></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
