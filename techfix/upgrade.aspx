<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="upgrade.aspx.cs" Inherits="techfix.upgrade" %>
<%@ Register Src="~/NavBar.ascx" TagPrefix="uc" TagName="NavBar" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Tech Fix - Special Offers</title>
    <link rel="stylesheet" href="Styles.css" />
    <style>
        /* Inline CSS for quick setup, can be moved to Styles.css later */
        .container {
            max-width: 1200px;
            margin: 0 auto;
            padding: 20px;
        }
        .hero-section {
            background: url(img/nnn.jpg) no-repeat center center;
            background-size: cover;
            padding: 60px 20px;
            color: white;
            text-align: left;
            position: relative;
            margin-left: -110px;
            margin-right: -110px;
            height: 500px;
            margin-top: -22px;
        }
        .hero-content {
            max-width: 600px;
            margin-left: 900px;
            margin-top: 100px;
        }
        
        .hero-content h2 {
            font-size: 36px;
            line-height: 1.4;
            margin-bottom: 20px;
        }

        .upgrade-btn {
            background-color: #FF3B3B;
            color: white;
            border: none;
            padding: 15px 30px;
            cursor: pointer;
            font-size: 18px;
            transition: background-color 0.3s ease;
        }

        .upgrade-btn:hover {
            background-color: #d32f2f;
        }

        .offers-section {
            margin-top: 40px;
        }

        .offers-section h2 {
            font-size: 28px;
            margin-bottom: 20px;
            color: #ffffff;
        }
        .offer {
            display: flex;
            border: 1px solid #ddd;
            margin-bottom: 20px;
            padding: 15px;
        }
        .offer-image {
            width: 150px;
            height: auto;
            margin-right: 20px;
        }
        .offer-details {
            flex: 1;
            
        }
        .offer-details h3 {
            font-size: 22px;
            margin-bottom: 10px;
            color: white;
            margin-left: 19px;
        }
        .offer-details p {
            margin-bottom: 5px;
        }
        .price {
            color: #FF3B3B;
            font-weight: bold;
            font-size: 20px;
        }

        .h3-class{
            font-size: 18px;
            color: #585454;
            font-weight: bold;
        }

        .h2-class{
            font-weight: bold;
    color: #3A3838;
        }
    </style>
</head>
<body>
    <uc:NavBar ID="NavBar1" runat="server" />
        <div class="container">
            <!-- Hero Section -->
            <div class="hero-section">
                <div class="hero-content">
                    <h3 class="h3-class">Find any forms of computer,</h3> <h2 class="h2-class">HARDWARE YOU NEED</h2>
                    <a href="pcbuild.aspx">
                        <button class="upgrade-btn">Upgrade</button>
                    </a>
                </div>
            </div>

            <!-- Special Offers Section -->
            <div class="offers-section">
                <h2>Special offers</h2>
                <div class="offer">
                    <img src="img/team_elite_8gb_ddr4.jpg" alt="DDR 4 8GB RAM" class="offer-image" />
                    <div class="offer-details">
                        <h3>DDR 4 8GB RAM</h3>
                        <p>Refers to the total number worldwide. Not all content is available in all countries.</p>
                        <p class="price">RS. 25,000.00</p>
                    </div>
                </div>
                <div class="offer">
                    <img src="img/gskill_32gb_ddr4.jpg" alt="DDR 4 8GB RAM" class="offer-image" />
                    <div class="offer-details">
                        <h3>DDR 4 8GB RAM</h3>
                        <p>Refers to the total number worldwide. Not all content is available in all countries.</p>
                        <p class="price">RS. 25,000.00</p>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/particles.js/2.0.0/particles.min.js"></script>
    <script src="js/custom_particles.js"></script>
</body>
</html>
