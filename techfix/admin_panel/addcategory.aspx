<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addcategory.aspx.cs" Inherits="techfix.admin_panel.addcategory" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Category</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        .custom-header {
            background-color: #007bff; /* Custom header color */
            color: white;
        }
        
    </style>
    <script type="text/javascript">
        // Function to show a success message after deletion
        function showSuccessModal() {
            alert('Category deleted successfully!');
        }

        // Function to confirm deletion before proceeding
        function confirmDelete() {
            return confirm("Are you sure you want to delete this category?");
        }
    </script>
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
                            <h6 class="mb-4">Item category</h6>
                            <div class="table-responsive">
                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False"
                                        OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" DataKeyNames="id">

                                    <HeaderStyle CssClass="custom-header" />
                                    <RowStyle CssClass="custom-row" />
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="ID" />
                                        <asp:BoundField DataField="category_name" HeaderText="Category Name" />
                                        <asp:TemplateField HeaderText="Image">
                                            <ItemTemplate>
                                                <img src='<%# "../img/" + Eval("image_name") %>' alt='<%# Eval("category_name") %>' style="width:100px;height:auto;" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Actions">
                                            <ItemTemplate>
                                               <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-warning btn-sm" />
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-danger btn-sm"
                                                            OnClientClick="return confirmDelete();" />
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
