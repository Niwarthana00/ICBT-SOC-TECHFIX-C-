<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_order.aspx.cs" Inherits="techfix.supplier1.home" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Analysis</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/sidebar.css" rel="stylesheet" />
     <style>
     /* Custom table styling */
        .custom-table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }

        .custom-table th, .custom-table td {
            border: 1px solid #dee2e6 !important; /* Ensures a visible border */
            padding: 10px;
            text-align: left;
        }

        .custom-table th {
            background-color: #f2f2f2;
            font-weight: bold;
        }



         /* Custom header style */
         .custom-header {
             background-color: #FF3333;
             color: white;
             font-weight: bold;
             text-align: center;
         }

         .custom-header th {
             padding: 15px;
             font-size: 16px;
         }

         /* Row and alternating row styles */
         .custom-row {
             border-bottom: 1px solid #dee2e6;
             color: #a0a0a0;
         }

         .custom-alternating-row {
             background-color: #f2f2f2;
             border-bottom: 1px solid #dee2e6;
         }
     
         /* Table borders */
         .table-bordered {
             border: 1px solid #dee2e6;
             margin-left: 0px;
         }
     
         .table-bordered td, .table-bordered th {
             border: 1px solid #dee2e6;
         } 
  
        /* Optional: Styling for the GridView */
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
            margin-right: 564px;
            margin-left: -70px;
        }
        th, td {
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }
        th {
            background-color: #FF3333 !important;
            color: white;
        }
        .form-control:disabled, .form-control:read-only {
            background: #13151b;
            opacity: 1;
        }
        /* Custom styling */
        .dropdown-dark {
            background-color: #343a40; /* Dark color */
            color: #ffffff; /* White text */
        }
        .dropdown-dark option {
            color: #000000; /* Black text in dropdown options */
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
                        <h6 class="mb-4">Admin Orders</h6>
                        <!-- Month Filter Section -->
                        <div class="form-group">
                            <label for="monthSelect">Select Month:</label>
                            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control dropdown-dark" AutoPostBack="true" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                                <asp:ListItem Value="0" Selected="True">All</asp:ListItem>
                                <asp:ListItem Value="1">January</asp:ListItem>
                                <asp:ListItem Value="2">February</asp:ListItem>
                                <asp:ListItem Value="3">March</asp:ListItem>
                                <asp:ListItem Value="4">April</asp:ListItem>
                                <asp:ListItem Value="5">May</asp:ListItem>
                                <asp:ListItem Value="6">June</asp:ListItem>
                                <asp:ListItem Value="7">July</asp:ListItem>
                                <asp:ListItem Value="8">August</asp:ListItem>
                                <asp:ListItem Value="9">September</asp:ListItem>
                                <asp:ListItem Value="10">October</asp:ListItem>
                                <asp:ListItem Value="11">November</asp:ListItem>
                                <asp:ListItem Value="12">December</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <!-- Orders Table -->
                        <div class="table-responsive mt-4">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="Both" CssClass="table table-bordered custom-table">
                                <Columns>
                                    <asp:BoundField DataField="OrderId" HeaderText="Order ID" />
                                    <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                                    <asp:BoundField DataField="CustomerNumber" HeaderText="Customer Number" />
                                    <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                                    <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:yyyy-MM-dd}" />
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
