<%@ Register Src="~/NavBar.ascx" TagPrefix="uc" TagName="NavBar" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Repair Service</title>
    <link href="css/rep.css" rel="stylesheet" />
</head>
<body>
        <uc:NavBar ID="NavBar1" runat="server" />
        <div class="container">
            <!-- Header Section -->
            <div class="header">
                <div class = "new-al">
                    <p class="repair-item">Computer, Laptop,</p>
                    <h1>REPAIR SERVICE</h1>                
                    <p class="text-al">Expert Laptop and Computer Repair Services </p>
                    <p class="tl"> Fast, Reliable, and Affordable Solutions for All Your Tech Troubles! </p>
                  
                    <a href="appointment.aspx">
                        <button type="button">Make an Appointment</button>
                    </a>
                </div>
            </div>

            <!-- How It Works Section -->
            <div class="how-it-works">
    <h2>HOW IT WORKS</h2>
    <div class="steps">
        
        <div class="step">
            <div class="step-header">
                <img src="img/pc.png" alt="Bring Devices" />
                <h3>01.</h3>
            </div>
            <div class="step-content">
                <h4>Bring Damage Devices</h4>
                <p>Experienced service department ready to handle all of your repair needs.</p>
            </div>
        </div>

        <div class="step">
            <div class="step-header">
                <img src="img/setting.png" alt="Diagnosis" />
                <h3>02.</h3>
            </div>
            <div class="step-content">
                <h4>Diagnosis & Solve Issue</h4>
                <p>We perform detailed diagnosis to find and fix the problem.</p>
            </div>
        </div>
        
        <div class="step">
            <div class="step-header">
                <img src="img/clock.png" alt="Return Devices" />
                <h3>03.</h3>
            </div>
            <div class="step-content">
                <h4>Return Perfect Devices</h4>
                <p>Get your device back in perfect working condition.</p>
            </div>
        </div>
    </div>
</div>           
     <a href="appointment.aspx" class="btn-appoinment">
         Make an Appointment
     </a>
    </div>

    <!--carousel -->
    <hr class="line"/>
    <div class="carousel">
    <h1 class="topic"> QUALITY SOLUTIONS</h1>
    <div class="carousel-track-container">
        <ul class="carousel-track">
            <li class="carousel-slide current-slide">
                <a href="laptop-repair.aspx">
                    <img src="img/lap.png" alt="Laptop Repair">
                    <p class="carousel-captions">Laptop Repair</p>
                </a>
            </li>
            <li class="carousel-slide">
                <a href="processor-repair.aspx">
                    <img src="img/pro.png" alt="Processor Repair">
                    <p class="carousel-captions">Processor Repair</p>
                </a>
            </li>
            <li class="carousel-slide">
                <a href="motherboard-fix.aspx">
                    <img src="img/moth.png" alt="Motherboard Fix">
                    <p class="carousel-captions">Motherboard Fix</p>
                </a>
            </li>
            <li class="carousel-slide">
                <a href="ram-installation.aspx">
                    <img src="img/ramre.png" alt="RAM Installation">
                    <p class="carousel-captions">RAM Installation</p>
                </a>
            </li>
        </ul>
    </div>
    
</div>
    </form>
    <script src="path/to/bootstrap.bundle.min.js"></script> <!-- Ensure to link Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/particles.js/2.0.0/particles.min.js"></script>
    <script src="js/custom_particles.js"></script>
    <script src="js/main.js"></script>
</body>
</html>
