<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customer_details.aspx.cs" Inherits="techfix.admin_panel.customer_orders" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <title>Customer Orders</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/sidebar.css" rel="stylesheet" />
    <style>
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
        }
        
        .table-bordered td, .table-bordered th {
            border: 1px solid #dee2e6;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Sidebar ID="Sidebar" runat="server" />

        <div class="container-fluid position-relative d-flex p-0">
            <!-- Table Start -->
            <div class="container-fluid pt-4 px-4">
                <div class="row g-4">  
                    <div class="col-12">
                        <div class="bg-secondary rounded h-100 p-4">
                            <h6 class="mb-4">Customer Details</h6>
                            <div class="table-responsive">
                                <asp:GridView ID="customerTable" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False">
                                    <HeaderStyle CssClass="custom-header" />
                                    <RowStyle CssClass="custom-row" />
                                    
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" />
                                        <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" />
                                        <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Table End -->
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
