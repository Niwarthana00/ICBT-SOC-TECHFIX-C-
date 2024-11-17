<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editcategory.aspx.cs" Inherits="techfix.supplier1.editcategory" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Category</title>
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
            <div class="container mt-5">
                <div class="row g-4">
                    <div class="col-12">
                        <div class="bg-secondary rounded h-100 p-4">
                            <h2 class="text-white">Edit Category</h2>
                            <div class="form-group">
                                <label for="txtCategoryName" class="text-white">Category Name:</label>
                                <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control" />
                            </div>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClientClick="location.href='addcategory.aspx'; return false;" />
                            <asp:Label ID="lblMessage" runat="server" CssClass="text-success mt-3"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
