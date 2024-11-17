<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customer_orders.aspx.cs" Inherits="techfix.admin_panel.customer_orders1" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Orders</title>
    <style>
        /* Add some basic styling */
        .table-header {
            background-color: #FF3333;
            color: white;
            font-weight: bold;
            text-align: center;
        }

        .table-row, .table-alternating-row {
            border-bottom: 1px solid #ddd;
            text-align: left;
            padding: 8px;
        }

        

        .table-bordered {
            width: 100%;
            border-collapse: collapse;
        }

        .table-bordered th, .table-bordered td {
            border: 1px solid #ddd;
            padding: 8px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
      <uc1:Sidebar ID="Sidebar" runat="server" />
  <div class="container-fluid pt-4 px-4">
    <div class="row g-4">
        <div class="col-12">
            <div class="bg-secondary rounded h-100 p-4">
                <h6 class="mb-4">Customer Orders</h6>
                <div class="table-responsive">
                    <asp:GridView 
                        ID="CustomerOrdersGridView" 
                        runat="server" 
                        AutoGenerateColumns="False" 
                        CssClass="table-bordered" 
                        GridLines="None">
                
                        <HeaderStyle CssClass="table-header" />
                        <RowStyle CssClass="table-row" />
                        <AlternatingRowStyle CssClass="table-alternating-row" />

                        <Columns>
                            <asp:BoundField DataField="orderid" HeaderText="Order ID" />
                            <asp:BoundField DataField="customer_name" HeaderText="Customer Name" />
                            <asp:BoundField DataField="phone_number" HeaderText="Phone Number" />
                            <asp:BoundField DataField="address" HeaderText="Address" />
                            <asp:BoundField DataField="item_name" HeaderText="Item Name" />
                            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:C2}" />
                            <asp:BoundField DataField="order_total" HeaderText="Order Total" DataFormatString="{0:C2}" />
                            <asp:BoundField DataField="order_date" HeaderText="Order Date" DataFormatString="{0:yyyy-MM-dd}" />
                        </Columns>
                    </asp:GridView>
                </div>
              </div>
            </div>
        </div>
      </div>
    </form>
</body>
</html>
