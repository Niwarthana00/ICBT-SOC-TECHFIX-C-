<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="techfix.home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TechFix Computer Shop</title>
    <link href="css/styles.css" rel="stylesheet" />
    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-icons/1.5.0/font/bootstrap-icons.min.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navbar -->
        <nav class="navbar navbar-expand-lg navbar-dark fixed-top">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">
                    <img src="img/logo.png" alt="TechFix Logo" class="logo"> <!-- Replace with your logo -->
                </a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse justify-content-end" id="navbarNav">
                    <ul class="navbar-nav">
                        <li class="nav-item"><a class="nav-link active" href="#">Home</a></li>
                        <li class="nav-item"><a class="nav-link" href="#">Repair</a></li>
                        <li class="nav-item"><a class="nav-link" href="#">Upgrade</a></li>
                        <li class="nav-item"><a class="nav-link" href="#">Build PC</a></li>
                        <li class="nav-item"><a class="nav-link" href="#">Contact us</a></li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">
                                <i class="bi bi-cart"></i> <!-- Cart icon -->
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link">
                                <button class="login-btn">Login</button> <!-- Customized login button -->
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <!-- Particle Effect Section -->
        <div id="particles-js">
            <!-- Your main content goes here -->
            <div class="content-container">
                <!-- Example content like Carousel -->
                <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-indicators">
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                        <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
                    </div>
                    <div class="carousel-inner">
                        <div class="carousel-item active">
                            <img src="img/background2.png" class="d-block w-100" alt="Slide 1">
                            <div class="carousel-caption">
                                <h1 class="animated-heading caption" style="margin-bottom:10px;">Welcome To The</h1>
                                <img src="img/logo.png" alt="TechFix Logo" class="logo" style="max-width: 300px; height: auto; margin-top:30px;">
                                <p>Trust us to meet your needs with care and professionalism.</p>           
                            </div>
                        </div>
                        <div class="carousel-item">
                            <img src="img/background.png" class="d-block w-100" alt="Slide 2">
                            <div class="carousel-caption text-center">
                                <img src="img/msi.png" alt="Laptop" class="laptop-image" style="max-width: 400px; height: auto; margin-bottom: 10px;">
                                <a href="shop.html" class="shop-btn">Shop Now</a>
                            </div>
                        </div>
                        <div class="carousel-item">
                            <img src="img/asus.png" class="d-block w-100" alt="Slide 3">
                            <div class="carousel-caption text-center">
                                <img src="img/rog.png" alt="ROG Laptop" class="laptop-image" style="max-width: 300px;">
                                <a href="shop.html" class="shop-btn">Shop Now</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Particle Canvas -->
            <canvas class="particles-js-canvas-el"></canvas>
        </div>

        <!-- Footer Section -->
        <footer class="bg-dark text-light text-center py-4 mt-5">
            <div class="container">
                <p>&copy; 2024 TechFix Computer Shop. All Rights Reserved.</p>
                <a href="#" class="text-light me-3"><i class="bi bi-facebook"></i></a>
                <a href="#" class="text-light me-3"><i class="bi bi-twitter"></i></a>
                <a href="#" class="text-light"><i class="bi bi-instagram"></i></a>
            </div>
        </footer>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js"></script>

    <!-- Include Particles.js library -->
    <script src="https://cdn.jsdelivr.net/particles.js/2.0.0/particles.min.js"></script>
    <!-- Include custom particles configuration -->
    <script src="js/custom_particles.js"></script>
</body>
</html>