<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addproduct.aspx.cs" Inherits="techfix.supplier2.addproduct" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Product</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Sidebar ID="Sidebar" runat="server" />
        <div class="container-fluid position-relative d-flex p-0">
            <div class="container mt-5">
                <div class="row g-4">
                    <div class="col-12">
                        <div class="bg-secondary rounded h-100 p-4">
                            <h2 class="text-white">Add Product</h2>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="False"></asp:Label>

                            <div style="margin-top: 10px;">
                                <asp:Label ID="lblProductName" runat="server" Text="Product Name:"></asp:Label>
                                <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div style="margin-top: 10px;">
                                <asp:Label ID="lblImageUrl" runat="server" Text="Image URL:"></asp:Label>
                                <asp:TextBox ID="txtImageUrl" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div style="margin-top: 10px;">
                                <asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label>
                                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div style="margin-top: 10px;">
                                <asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label>
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div style="margin-top: 10px;">
                                <asp:Label ID="lblCategory" runat="server" Text="Category:"></asp:Label>
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>

                            <div style="margin-top: 10px;">
                                <asp:Label ID="lblQuantity" runat="server" Text="Quantity:"></asp:Label>
                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div style="margin-top: 20px;">
                                <asp:Button ID="btnSave" runat="server" Text="Save Product" OnClick="btnSave_Click" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
