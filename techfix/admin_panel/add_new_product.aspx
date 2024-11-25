<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_new_product.aspx.cs" Inherits="techfix.admin_panel.addnew" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Product</title>
</head>
<body>
<form id="form1" runat="server">
  <uc1:Sidebar ID="Sidebar" runat="server" />
   <div class="container-fluid position-relative d-flex p-0">
     <div class="container mt-5">
         <div class="row g-4">
             <div class="col-12">
                 <div class="bg-secondary rounded h-100 p-4">
                        <h2>Add New Product</h2>
                        <label for="txtItemName">Product Name:</label>
                        <asp:TextBox ID="txtItemName" runat="server" CssClass="form-control"></asp:TextBox>
                        <br />

                        <label for="ddlCategory">Category:</label>
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                        <br />

                        <label for="txtDescription">Description:</label>
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        <br />

                        <label for="txtPrice">Price:</label>
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" ></asp:TextBox>
                        <br />

                        <label for="txtImageURL">Image URL:</label>
 <asp:TextBox ID="txtImageURL" runat="server" CssClass="form-control" ></asp:TextBox>
 <br />

            <asp:Button ID="btnAddProduct" runat="server" Text="Add Product" OnClick="btnAddProduct_Click" CssClass="btn btn-primary" />
            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                </div>
               </div>
             </div>
         </div>
       </div>

    </form>
</body>
</html>
