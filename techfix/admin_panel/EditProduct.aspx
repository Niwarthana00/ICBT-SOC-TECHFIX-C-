<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="techfix.admin_panel.EditProduct" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Product</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        .custom-header {
            background-color: #007bff; /* Custom header color */
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <uc1:Sidebar ID="Sidebar" runat="server" />
        <div class="container-fluid position-relative d-flex p-0">
            <div class="container-fluid pt-4 px-4">
                <div class="row g-4">
                    <div class="col-12">
                        <div class="bg-secondary rounded h-100 p-4">
                            <h6 class="mb-4">Edit Product</h6>
                            <div>
                                <asp:Label ID="Label1" runat="server" Text="Item Name:" AssociatedControlID="txtItemName"></asp:Label>
                                <asp:TextBox ID="txtItemName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="Label2" runat="server" Text="Description:" AssociatedControlID="txtDescription"></asp:Label>
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="Label3" runat="server" Text="Price:" AssociatedControlID="txtPrice"></asp:Label>
                                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="Label4" runat="server" Text="Image:" AssociatedControlID="textImageURL"></asp:Label>
                                <asp:TextBox ID="textImageURL" runat="server" CssClass="form-control"></asp:TextBox>
                                <br />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                            </div>
                            <br />
                            <asp:Label ID="lblMessage" runat="server" CssClass="text-success"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
