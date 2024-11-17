<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="techfix.Checkout" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Checkout</title>
    <link href="css/styles.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/toastr.min.js"></script>
    <style>
        .checkout-container {
            display: flex;
            justify-content: space-between;
            margin-top: 50px;
            background-color: #383535;
        }
        .form-section, .summary-section {
            background-color: #383535;
            padding: 20px;
            border-radius: 8px;
            width: 48%;
            color: white;
        }
        .total-price {
            font-size: 1.2em;
            font-weight: bold;
            color: #898989;
        }
        .btn {
            width: 100%;
        }
        .pay-now-btn {
            background-color: #00721e;
            color: white;
        }
         .one{
            margin-left: 64px !important;
            background: none !important;
        }
         .two{
             margin-left: 29px !important;
             background: none !important;
         }
         .three{
             margin-left: 80px !important;
             width: 400px !important;
             background: none !important;
         }
         .four{
             margin-left: 41px !important;
             background: none !important;
         }
         .five{
                 margin-left: 170px !important;
                 background: none !important;
                 margin-bottom: 37px;
                 margin-top: -42px;
         }
         .six{
             margin-left: 105px !important;
             background: none !important;
         }
    </style>
</head>
<body style="background:#131212;">
    <form id="form1" runat="server">
        <div class="container checkout-container">
            <!-- Billing and Card Details Section -->
            <div class="form-section">
                <h2>Billing & Card Details</h2>
                <div class="mb-3">
                    <label for="fullName" class="form-label">Full Name</label>
                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-input one" Placeholder="Enter your full name"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="phoneNumber" class="form-label">Phone Number</label>
                    <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-input two" Placeholder="Enter your phone number"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="address" class="form-label">Address</label>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-input three" TextMode="MultiLine" Rows="3" Placeholder="Enter your address"></asp:TextBox>
                </div>
                <h3>Card Details</h3>
                <div class="mb-3">
                    <label for="cardNumber" class="form-label">Card Number</label>
                    <asp:TextBox ID="txtCardNumber" runat="server" CssClass="form-input four" Placeholder="Enter your card number"></asp:TextBox>
                </div>
                <div class="row mb-3">
                    <div class="col">
                        <label for="expirationDate" class="form-label">Expiration Date</label>
                        <asp:TextBox ID="txtExpirationDate" runat="server" CssClass="form-input five" Placeholder="MM/YY"></asp:TextBox>
                    </div>
                    <div class="col">
                        <label for="cvv" class="form-label">CVV</label>
                        <asp:TextBox ID="txtCVV" runat="server" CssClass="form-input six" Placeholder="CVV"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="btnPayNow" runat="server" Text="Pay Now" CssClass="btn pay-now-btn" OnClick="PayNow_Click" />
            </div>
            <!-- Order Summary Section -->
            <div class="summary-section">
                <h2 style="color:white; margin-bottom: 25px;">Order Summary</h2>
                <asp:ListView ID="lvOrderSummary" runat="server">
                    <ItemTemplate>
                        <div class="d-flex justify-content-between mb-2">
                            <span><%# Eval("ItemName") %> (x<%# Eval("Quantity") %>)</span>
                            <span>RS.<%# Eval("TotalPrice", "{0:0.00}") %></span>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
                <hr />
                <div class="d-flex justify-content-between total-price">
                    <span>Total:</span>
                    <span><asp:Label ID="grandTotalSummary" runat="server" Text="RS. 0.00"></asp:Label></span>
                </div>
    
                <!-- Back Button to Cart -->
                <asp:Button ID="btnBackToCart" runat="server" Text="Back to Cart" CssClass="btn btn-secondary mt-3" OnClick="BackToCart_Click" />
            </div>
        </div>
    </form>
    <script type="text/javascript">
        // Default toastr options
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": true,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };
    </script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
