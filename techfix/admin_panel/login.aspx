<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="techfix.admin_panel.login" %>

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
                          <h3 class="text-primary"><i class="fa fa-user-edit me-2"></i> Login now !</h3>
                      </a>
                      <h3>Login</h3>
                  </div>
                        <div class="form-group mb-3">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Password"></asp:TextBox>
                        </div>

                        
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger d-block text-center" Visible="false"></asp:Label>
                        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary w-100" Text="Login" OnClick="btnLogin_Click" />
                    </div>
                </div>
          </div>
      </div>
    </form>
</body>

</html>
