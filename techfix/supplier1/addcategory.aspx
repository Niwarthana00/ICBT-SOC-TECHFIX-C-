<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addcategory.aspx.cs" Inherits="techfix.supplier1.addcategory" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Category</title>
</head>
<body>
 <form id="form1" runat="server">
 <uc1:Sidebar ID="Sidebar" runat="server" />
  <div class="container-fluid position-relative d-flex p-0">
    <div class="container mt-5">
        <div class="row g-4">
            <div class="col-12">
                <div class="bg-secondary rounded h-100 p-4">
                    <h2 class="text-white">Add New Category</h2>
            
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Visible="False"></asp:Label>
            
                        <div style="margin-top: 10px;">
                            <asp:Label ID="lblCategoryName" runat="server" Text="Category Name:"></asp:Label>
                            <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
            
                        <div style="margin-top: 10px;">
                            <asp:Button ID="btnSave" runat="server" Text="Save Category" OnClick="btnSave_Click" CssClass="btn btn-primary" />
                        </div>
                     </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
