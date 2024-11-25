<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addproduct.aspx.cs" Inherits="techfix.admin_panel.addproduct" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Product</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        .custom-header {
            background-color: #007bff; /* Custom header color */
            color: white;
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
                            <h6 class="mb-4">Item Category</h6>
                            <div class="table-responsive">
                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand">
                                    <HeaderStyle CssClass="custom-header" />
                                    <RowStyle CssClass="custom-row" />
                                    <Columns>
                                        <asp:BoundField DataField="item_id" HeaderText="ID" />
                                        <asp:BoundField DataField="item_name" HeaderText="Name" />
                                        <asp:BoundField DataField="description" HeaderText="Description" />
                                        <asp:BoundField DataField="price" HeaderText="Price" />
                                        <asp:TemplateField HeaderText="Image">
                                            <ItemTemplate>
                                                <img src='<%# "" + Eval("image_name") %>' alt='<%# Eval("item_name") %>' style="width:100px;height:auto;" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Actions">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" runat="server" CommandName="EditItem" CommandArgument='<%# Eval("item_id") %>' Text="Edit" CssClass="btn btn-warning" />
                                                <asp:Button ID="btnDelete" runat="server" CommandName="DeleteItem" CommandArgument='<%# Eval("item_id") %>' Text="Delete" CssClass="btn btn-danger" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
</body>
</html>
