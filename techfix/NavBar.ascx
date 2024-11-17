﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavBar.ascx.cs" Inherits="techfix.NavBar" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

    <title>TechFix - Repair Section</title>
    <link href="css/styles.css" rel="stylesheet" />
    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-icons/1.5.0/font/bootstrap-icons.min.css" rel="stylesheet">
</head>
<body style="background-color: #101010;">
    <form id="form1" runat="server">
      <!-- Navbar -->
<nav class="navbar navbar-expand-lg navbar-dark fixed-top">
    <div class="container-fluid">
        <a class="navbar-brand" href="home.aspx">
            <img src="img/logo.png" alt="TechFix Logo" class="logo"> 
        </a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse justify-content-end" id="navbarNav">
            <ul class="navbar-nav">
                <li class="nav-item"><a class="nav-link active" href="home.aspx">Home</a></li>
                <li class="nav-item"><a class="nav-link" href="repair.aspx">Repair</a></li>
                <li class="nav-item"><a class="nav-link" href="upgrade.aspx">Upgrade</a></li>
                <li class="nav-item"><a class="nav-link" href="pcbuild.aspx">Build PC</a></li>
                <li class="nav-item"><a class="nav-link" href="contact.aspx">Contact us</a></li>
                <li class="nav-item">
                    <a class="nav-link" href="Cart.aspx">
                        <i class="bi bi-cart"></i> <!-- Cart icon -->
                    </a>
                </li>

                <!-- User Dropdown -->
                <li class="nav-item dropdown">
                    <% if (Session["Email"] != null) { %>
                        <!-- If user is logged in, show profile icon with dropdown -->
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                            <i class="bi bi-person-circle"></i> <!-- Profile icon -->
                        </a>
                        <ul class="dropdown-menu dropdown-menu-end" aria-labelledby="navbarDropdown">
                            <!-- Display user's email -->
                            <li>
                                <a class="dropdown-item" href="#">
                                    <span class="user-email">Hello, <%= Session["Email"].ToString() %></span>
                                </a>
                            </li>
                            <li><hr class="dropdown-divider"></li>
                            <!-- Logout button -->
                            <li>
                                <asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click" CssClass="dropdown-item">Logout</asp:LinkButton>
                            </li>
                        </ul>
                    <% } else { %>
                        <!-- If the user is not logged in, show the login button -->
                        <a class="nav-link" href="#" data-bs-toggle="modal" data-bs-target="#loginModal">
                            <button class="login-btn">Login</button>
                        </a>
                    <% } %>
                </li>
            </ul>
        </div>
    </div>
</nav>


        <!-- Login Modal -->
        <div class="modal fade" id="loginModal" tabindex="-1" aria-labelledby="loginModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header text-center">
                        <h5 class="modal-title" id="loginModalLabel">LOGIN TO TECH FIX</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" style="color: white; background-color: white;"></button>
                    </div>
                    <div class="modal-body">
                        <center><img src="img/logo.png" alt="TechFix Logo" class="modal-logo"></center>
                        <asp:TextBox ID="txtLoginEmail" runat="server" CssClass="form-control" placeholder="Enter your email"></asp:TextBox><br />
                        <asp:TextBox ID="txtLoginPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter your password"></asp:TextBox><br />
                        <p class="havent">You don't have an account? 
                            <a href="#" data-bs-toggle="modal" data-bs-target="#signupModal" data-bs-dismiss="modal">Register</a>
                        </p>
                        <asp:Button ID="btnLogin" runat="server" CssClass="btn-login-modal" Text="Login" OnClick="btnLogin_Click" />
                    </div>
                </div>
            </div>
        </div>

        <!-- Sign-Up Modal -->
        <div class="modal fade" id="signupModal" tabindex="-1" aria-labelledby="signupModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header text-center">
                        <h5 class="modal-title" id="signupModalLabel">REGISTER TO TECH FIX</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" style="color: white; background-color: white;"></button>
                    </div>
                    <div class="modal-body">
                        <center><img src="img/logo.png" alt="TechFix Logo" class="modal-logo"></center>
                        <div class="mb-3">
                            <label for="name" class="form-label">Full Name</label>
                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server" placeholder="Enter your full name"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="address" class="form-label">Enter your address</label>
                            <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" placeholder="Address"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="number" class="form-label">Enter your Contact number</label>
                            <asp:TextBox ID="txtContact" CssClass="form-control" runat="server" placeholder="Contact number"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="email1" class="form-label">Enter your Email address</label>
                            <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" runat="server" placeholder="Email address"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="password1" class="form-label">Create Password</label>
                            <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server" placeholder="Create your password"></asp:TextBox>
                        </div>
                        <p class="already">Already have an account? 
                            <a href="#" data-bs-toggle="modal" data-bs-target="#loginModal" data-bs-dismiss="modal">Login</a>
                        </p>
                        <asp:Button ID="btnRegister" CssClass="btn-login-modal" runat="server" Text="REGISTER" OnClick="btnRegister_Click" />
                    </div>
                </div>
            </div>
        </div>

    </form>
    <script src="path/to/bootstrap.bundle.min.js"></script> <!-- Ensure to link Bootstrap JS -->
</body>
</html>
