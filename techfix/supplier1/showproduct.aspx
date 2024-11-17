<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showproduct.aspx.cs" Inherits="techfix.supplier1.showproduct" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product List</title>
    <style>
        .gridview-table {
            border: 1px solid #ccc;
            width: 100%;
        }
        .gridview-table th, .gridview-table td {
            border: 1px solid #ccc;
            padding: 8px;
            text-align: center;
        }
        .small-column {
            width: 100px;
        }
        .action-buttons {
            display: inline-flex;
            gap: 8px;
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
                            <h6 class="mb-4">Item Product</h6>
                            <div class="table-responsive">
                                <asp:GridView ID="ProductGridView" runat="server" AutoGenerateColumns="False" CssClass="gridview-table" OnRowCommand="ProductGridView_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="ID" />
                                        <asp:BoundField DataField="product_name" HeaderText="Product Name" />
                                        <asp:ImageField DataImageUrlField="FullImagePath" HeaderText="Image" ControlStyle-Width="100px" ControlStyle-Height="100px" />
                                        <asp:BoundField DataField="price" HeaderText="Price" DataFormatString="{0:C}" />
                                        <asp:BoundField DataField="description" HeaderText="Description" />
                                        <asp:BoundField DataField="qty" HeaderText="Availability" ItemStyle-CssClass="small-column" />
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <div class="action-buttons">
                                                    <asp:LinkButton ID="EditButton" runat="server" Text="Edit" CommandName="EditProduct" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-primary btn-sm"></asp:LinkButton>
                                                    <asp:LinkButton ID="DeleteButton" runat="server" Text="Delete" CommandName="DeleteProduct" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this product?');"></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
