<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="singup.aspx.cs" Inherits="techfix.admin_panel.singup" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Sign Up</title>
    <!-- Favicon -->
    <link href="img/favicon.ico" rel="icon" type="image/x-icon" />
    <!-- Bootstrap and Custom CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <style>
        .form-selected{
            background:black !important;
        }

        @media (min-width: 1200px) {
    .col-xl-4 {
        flex: 0 0 auto;
        width: 700px;
    }
}
    </style>


</head>
<body>
 <form id="form1" runat="server">
   <div class="container-fluid position-relative d-flex p-0">
     <!-- Sign Up Start -->
     <div class="container-fluid">
         <div class="row h-100 align-items-center justify-content-center" style="min-height: 100vh;">
             <div class="col-6 col-sm-8 col-md-6 col-lg-5 col-xl-4" style ="width:100;">
                 <div class="bg-secondary rounded p-4 p-sm-5 my-4 mx-3">
                     <div class="d-flex align-items-center justify-content-between mb-3">
                         <a href="#" class="">
                             <h3 class="text-primary"><i class="fa fa-user-edit me-2"></i>Signup now !</h3>
                         </a>
                         <h3>Sign Up</h3>
                     </div>
                        <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label><br />
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Width="100%"></asp:TextBox><br /><br />

                        <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label><br />
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Width="100%"></asp:TextBox><br /><br />

                        <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label><br />
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Width="100%"></asp:TextBox><br /><br />

                        <asp:Label ID="lblRole" runat="server" Text="Role:"></asp:Label><br/>
                        <asp:DropDownList   ID="ddlRole" runat="server" CssClass="form-selected form-control"  Width="100%">
                            <asp:ListItem Text="Select Role" Value=""></asp:ListItem>
                            <asp:ListItem Text="Admin" Value="Admin"></asp:ListItem>
                            <asp:ListItem Text="Supplier" Value="Supplier"></asp:ListItem>
                        </asp:DropDownList><br /><br />

                        <p class="text-center mb-0" style="margin-right: -309px;"> Already have an Account? <a href="login.aspx"> Login</a></p> <br />

                        <asp:Button ID="btnSubmit" runat="server" Text="Sign Up" CssClass="btn btn-primary py-3 w-100 mb-4" OnClick="btnSubmit_Click" Width="100%" /><br /><br />
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                  </div>
                 </div>
             </div>
         </div>
       </div>
    </form>
</body>
</html>
