<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_new_category.aspx.cs" Inherits="techfix.admin_panel.add_new_category" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Category</title>
    <style>
        /* Overall form styling */
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f2f5;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            margin: 0;
        }

        /* Card styling */
        .card {
             background-color: #191C24 !important;
             color: #fff;
             width: 1900px !important;
             padding: 20px;
             margin: 30px;
             border-radius: 0px !important;
             box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
             height: 426px;
             margin-right: 1180px;
             margin-top: 82px;
        }

        /* Heading styling */
        .card h2 {
            margin-top: 0;
            font-size: 1.5em;
            text-align: center;
        }

        /* Label and input styling */
        .card label {
            display: block;
            margin: 15px 0 5px;
            color: #ddd;
        }

        .card input[type="text"], .card input[type="file"], .card .aspNet-Button {
            width: 100%;
            padding: 8px;
            margin-top: 5px;
            border-radius: 0px;
            border: 1px solid #555;
            background: none;
            color: #fff;
        }

        /* Button styling */
        .card .aspNet-Button {
            background-color: #FF3333;
            color: #fff;
            cursor: pointer;
            margin-top: 20px;
            border: none;
        }

        

        /* Message label */
        .card .message-label {
            margin-top: 10px;
            display: block;
            text-align: center;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Sidebar ID="Sidebar" runat="server" />
        <div class="card">
            <h2>Add New Category</h2>
            
            <label for="categoryName">Category Name:</label>
            <asp:TextBox ID="categoryName" runat="server" CssClass="text-box" required="true" /><br />

            <label for="imageUpload">Select Image:</label>
            <asp:FileUpload ID="imageUpload" runat="server" CssClass="file-upload" accept="image/*" /><br />

            <asp:Button ID="btnAddCategory" runat="server" CssClass="aspNet-Button" Text="Add Category" OnClick="btnAddCategory_Click" /><br />
            
            <asp:Label ID="lblMessage" runat="server" CssClass="message-label" ForeColor="Green"></asp:Label>
        </div>
    </form>
</body>
</html>
