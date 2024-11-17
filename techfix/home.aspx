<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="techfix.home" %>
<%@ Register Src="~/NavBar.ascx" TagPrefix="uc" TagName="NavBar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

    <title>TechFix Computer Shop</title>
    <link href="css/styles.css" rel="stylesheet" />

    <!-- Bootstrap CSS -->

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-icons/1.5.0/font/bootstrap-icons.min.css" rel="stylesheet">
</head>
<body style="background-color: #101010;">
    <uc:NavBar ID="NavBar1" runat="server" />
   
        <!-- Carousel -->

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
                        <img src="img/msilogo.png" alt="MSI Logo" class="logo" style="max-width: 250px; height: auto; margin-bottom: 10px;"> <br />
                        <a href="shop.html" class="shop-btn">Shop Now</a>
                    </div>
                </div>

                <div class="carousel-item">
                    <img src="img/asus.png" class="d-block w-100" alt="Slide 3">
                    <div class="carousel-caption text-center">
                        <img src="img/rog.png" alt="ROG Laptop" class="laptop-image" style="max-width: 300px; height: auto; margin-bottom: 50px; margin-right:255px; margin-top:-25px;"> <br />
                       <a href="shop.html" class="shop-btn">Shop Now</a>
                    </div>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>

  

<div class="container about-us-section" >
     <h1 class="about-us-heading"> About<span style="color:#FF3333">Us</span></h1> 
    
    <div class="row">
        <div class="col-lg-6 col-md-12 about-us-image">
            <img src="img/comp.jpg" alt="TechFix Shop" class="img-fluid">
        </div>
        <div class="col-lg-6 col-md-12 about-us-content">
            <h2 class="about-us-title"> TechFix</h2>
            <p class="about-us-text">
                “TechFix” is a well-known IT solutions provider. Since its establishment, TechFix has dedicated itself to offering trusted IT services to users through collaborations with leading brands. These partnerships include brands like Asus, Dell, MSI, HP, and many more.
            </p>
           <p class="about-us-text">
                At TechFix, we emphasize customer satisfaction through excellent service. Our qualified technicians are available to provide repair 
                and consulting services, ensuring your technology works seamlessly. We also offer remote support, diagnostics, and personalized 
                technical advice to help you make informed decisions about your tech. Whether it's for home or business, our team is committed 
                to delivering reliable and timely solutions that meet your specific needs.
            </p>

            <p class="about-us-text">
                With nearly a decade of experience in the IT industry, TechFix continues to deliver top-notch service by combining expertise with the latest 
                technological solutions. We aim to be your one-stop solution for all tech-related needs. Our services range from hardware repairs,
                software troubleshooting, and network setups to providing consulting services for businesses and individuals. At TechFix, 
                we believe in continuous improvement and innovation to ensure that our customers receive 
                the most efficient and up-to-date solutions.
             </p>
        </div>
    </div>
</div>

    <div class="service-icons">
        <div class="icon-container">
            <img src="img/customer.png" alt="Customer Service" class="service-icon">
               <p class="icon-text">CUSTOMER SERVICE</p>
        </div>
        <div class="icon-container">
            <img src="img/service.png" alt="Best Services" class="service-icon">
                <p class="icon-text">BEST SERVICES</p>
        </div>
        <div class="icon-container">
            <img src="img/hand2.png" alt="Support Team" class="service-icon">
                <p class="icon-text">SUPPORT TEAM</p>
        </div>
        <div class="icon-container">
            <img src="img/best.png" alt="Best Services" class="service-icon">
                <p class="icon-text">BEST SERVICES</p>
        </div>
    </div>

    <hr style=" color: white;">        
 <section id="repairs-upgrades">
  <h2 class ="color">Repairs, Upgrades & Custom PC Builds</h2>
  
  <!-- Horizontal Line using hr tag -->
  
  
  <p>  At TechFix (PVT) LTD, we offer specialized services to ensure your systems are always running at their best. <br />Whether you need quick repairs, system upgrades, or a custom-built PC, our experienced team is here to help. Explore our range of services below:</p>

  <!-- Repairs Section -->
  <div class="service-item">
    <img src="img/repair.png" alt="Repairs Icon" style="width:50px;">
    <h3 class ="color">Repairs</h3>
    <p>Our skilled technicians handle a variety of hardware and software repairs to get your systems back on track. We ensure minimum downtime and fast turnaround.</p>
    <ul class ="color">
      <li>Hardware diagnostics and replacement</li>
      <li>Operating system troubleshooting</li>
      <li>Software and driver updates</li>
    </ul>
  </div>
  
  <!-- Upgrades Section -->
  <div class="service-item">
    <img src="img/upgrade.png" alt="Upgrades Icon" style="width:50px;">
    <h3 class ="color">Upgrades</h3>
    <p>Enhance the performance and efficiency of your systems with our upgrade services. We offer tailored solutions to meet your specific requirements.</p>
    <ul class ="color">
      <li>Memory (RAM) and storage upgrades</li>
      <li>Graphics card installations</li>
      <li>Processor and motherboard upgrades</li>
    </ul>
  </div>

  <!-- Custom PC Builds Section -->
  <div class="service-item">
    <img src="img/build.png" alt="Custom PC Builds Icon" style="width:50px;">
    <h3 class ="color">Custom PC Builds</h3>
    <p>We specialize in building custom PCs for various needs, from gaming and multimedia to business and productivity. Let us design and build the perfect PC for you.</p>
    <ul class ="color">
      <li>Custom gaming rigs</li>
      <li>Workstation PCs for heavy tasks</li>
      <li>Balanced builds for everyday use</li>
    </ul>
  </div>
</section>



<!-- About section End -->


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
    <script src="https://cdn.jsdelivr.net/particles.js/2.0.0/particles.min.js"></script>
    <script src="js/custom_particles.js"></script>
   

   
</body>
</html>
