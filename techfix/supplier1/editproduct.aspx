<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editproduct.aspx.cs" Inherits="techfix.supplier1.editproduct" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Product</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Sidebar ID="Sidebar" runat="server" />
        <div class="container-fluid position-relative d-flex p-0">
            <div class="container-fluid pt-4 px-4">
                <div class="row g-4">
                    <div class="col-12">
                        <div class="bg-secondary rounded h-100 p-4">
                            <h6 class="mb-4">Edit Product</h6>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="False"></asp:Label>
                            <div>
                                <asp:Label ID="lblProductName" runat="server" Text="Product Name:"></asp:Label>
                                <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label>
                                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lblDescription" runat="server" Text="Description:"></asp:Label>
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lblAvailability" runat="server" Text="Availability:"></asp:Label>
                                <asp:TextBox ID="txtAvailability" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="image" runat="server" Text="Image URL:"></asp:Label>
                                <asp:TextBox ID="imgurl" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Image ID="imgPreview" runat="server" CssClass="img-thumbnail" Visible="False" Width="150px" Height="150px" />
                            </div>

                            <div>
                                <asp:Button ID="btnSave" runat="server" Text="Update Product" OnClick="btnSave_Click" CssClass="btn btn-primary" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-secondary" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
