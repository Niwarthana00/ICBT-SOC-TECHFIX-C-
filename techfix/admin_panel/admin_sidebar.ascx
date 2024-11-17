<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="admin_sidebar.ascx.cs" Inherits="techfix.admin_panel.admin_sidebar" %>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <title>DarkPan - Bootstrap 5 Admin Template</title>
    <!-- Icon Font Stylesheet -->
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.10.0/css/all.min.css" rel="stylesheet">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.1/font/bootstrap-icons.css" rel="stylesheet">

    <!-- Customized Bootstrap Stylesheet -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Template Stylesheet -->
    <link href="css/style.css" rel="stylesheet">
</head>

<body>
    <div class="container-fluid position-relative d-flex p-0">
     
        <!-- Sidebar Start -->
        <div class="sidebar pe-4 pb-3">
            <nav class="navbar bg-secondary navbar-dark ">
                <a href="index.html" class="navbar-brand mx-4 mb-3">
                    <h3 class="text-primary"><i class="fa fa-user-edit me-2"></i>Admin </h3>
                </a>
                <div class="d-flex align-items-center ms-4 mb-4">
                </div>
                <div class="navbar-nav w-100">
                    <a href="dashboard.aspx" class="nav-item nav-link active"><i class="fa fa-tachometer-alt me-2"></i>Dashboard</a>

                    <div class="nav-item dropdown">
                        <a href="#" class="nav-link dropdown-toggle" data-bs-toggle="dropdown"><i class="fa fa-users" aria-hidden="true"></i> Cutomer</a>
                        <div class="dropdown-menu bg-transparent border-0">
                            <a href="customer_details.aspx" class="dropdown-item">Details</a>
                            <a href="customer_msg.aspx" class="dropdown-item">Messages</a>
                            <a href="customer_orders.aspx" class="dropdown-item">Orders</a>
                            <a href="admin_appoignment.aspx" class="dropdown-item">Appoingment</a>
                        </div>
                    </div>

                <div class="nav-item dropdown">
                    <a href="" class="nav-link dropdown-toggle" data-bs-toggle="dropdown"><i class="fa fa-plus" aria-hidden="true"></i> Add</a>
                    <div class="dropdown-menu bg-transparent border-0">
                        <a href="addcategory.aspx" class="dropdown-item">Category</a>
                        <a href="addproduct.aspx" class="dropdown-item">Product</a>
                        <a href="add_new_category.aspx" class="dropdown-item">Add category</a>
                        <a href="add_new_product.aspx" class="dropdown-item">Add product</a>
                    </div>
                </div>
                    
                    <div class="nav-item dropdown">
                        <a href="supplier1_order.aspx" class="nav-link dropdown-toggle" data-bs-toggle="dropdown"><i class="fa fa-male" aria-hidden="true"></i> Supplier 1</a>
                        <div class="dropdown-menu bg-transparent border-0">
                            <a href="supplier1_order.aspx" class="dropdown-item">inventory</a>
                        </div>
                    </div>

                    <div class="nav-item dropdown">
                        <a href="supplier2_order.aspx" class="nav-link dropdown-toggle" data-bs-toggle="dropdown"><i class="fa fa-male" aria-hidden="true"></i> Supplier 2</a>
                        <div class="dropdown-menu bg-transparent border-0">
                            <a href="supplier2_order.aspx" class="dropdown-item">inventory</a>
                        </div>
                    </div>

                    <a href="compare.aspx"  class="nav-link"><i class="fa fa-compress" aria-hidden="true"></i>Compare</a>
                    <div class="nav-item dropdown">
                        <a href="" class="nav-link dropdown-toggle" data-bs-toggle="dropdown"><i class="fa fa-male" aria-hidden="true"></i> Analyze</a>
                        <div class="dropdown-menu bg-transparent border-0">
                            <a href="s1analyze.aspx" class="dropdown-item">Supplier 1</a>
                            <a href="s2analyze.aspx" class="dropdown-item">Supplier 2</a>
                        </div>
                    </div>


                </div>
            </nav>
        </div>
        <div class="content">
            <!-- Navbar Start -->
  
        <!-- Sidebar End -->
    </div>

    <!-- JavaScript Libraries -->
    <script src="https://code.jquery.com/jquery-3.4.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="lib/chart/chart.min.js"></script>
    <script src="lib/easing/easing.min.js"></script>
    <script src="lib/waypoints/waypoints.min.js"></script>
    <script src="lib/owlcarousel/owl.carousel.min.js"></script>
    <script src="lib/tempusdominus/js/moment.min.js"></script>
    <script src="lib/tempusdominus/js/moment-timezone.min.js"></script>
    <script src="lib/tempusdominus/js/tempusdominus-bootstrap-4.min.js"></script>

    <!-- Template Javascript -->
    
</body>

</html>