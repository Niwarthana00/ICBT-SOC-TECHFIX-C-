<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_appointment.aspx.cs" Inherits="techfix.admin_panel.admin_appointment" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Appointment Data</title>
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
                            <h6 class="mb-4">Customer Appoingments</h6>
                            <div class="table-responsive">
                                <asp:GridView 
                                    ID="AppointmentGridView" 
                                    runat="server" 
                                    AutoGenerateColumns="False" 
                                    GridLines="None" 
                                    CssClass="table-bordered">
                                    <HeaderStyle CssClass="custom-header" />
                                    <RowStyle CssClass="custom-row" />
                                    <AlternatingRowStyle CssClass="custom-alternating-row" />
                                    <Columns>
                                        <asp:BoundField DataField="AppointmentID" HeaderText="Appointment ID" />
                                        <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
                                        <asp:BoundField DataField="Phone" HeaderText="Phone" />
                                        <asp:BoundField DataField="Message" HeaderText="Message" />
                                        <asp:BoundField DataField="AppointmentDate" HeaderText="Appointment Date" DataFormatString="{0:yyyy-MM-dd}" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
