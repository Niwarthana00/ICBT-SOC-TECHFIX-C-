<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showcategorys1.aspx.cs" Inherits="techfix.supplier2.showcategorys1" %>
<%@ Register Src="admin_sidebar.ascx" TagName="Sidebar" TagPrefix="uc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Show Category</title>
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
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="ID" />
                                        <asp:BoundField DataField="category_name" HeaderText="Category Name" />
                                        <asp:TemplateField HeaderText="Actions">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-warning btn-sm" />
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
    
    <!-- Success Modal -->
    <div class="modal fade" id="successModal" tabindex="-1" aria-labelledby="successModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="successModalLabel">Success</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    Category successfully deleted!
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">OK</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Add jQuery and Bootstrap JavaScript for modal functionality -->
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.bundle.min.js"></script>
    <script>
        function showSuccessModal() {
            $('#successModal').modal('show');
        }
    </script>
</body>
</html>
