<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="item.aspx.cs" Inherits="techfix.item" %>
<%@ Register Src="~/NavBar.ascx" TagPrefix="uc" TagName="NavBar" %>
<%@ Register Src="~/SideBar.ascx" TagPrefix="uc" TagName="SideBar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Items</title>
    <link href="css/styles.css" rel="stylesheet" />
    <link href="css/repair.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-icons/1.5.0/font/bootstrap-icons.min.css" rel="stylesheet">
    <style>
    .custom-modal-body {
        display: flex;
        align-items: flex-start;
        gap: 20px;
    }

    .custom-item-image img {
        max-width: 100%;
        height: auto;
        max-height: 300px; 
        border-radius: 10px;
    }

    .custom-item-details {
        display: flex;
        flex-direction: column;
        gap: 15px;
    }

    .custom-item-details h4 {
        margin: 0;
        font-size: 1.5rem;
        font-weight: bold;
    }

    .custom-item-details div {
        font-size: 1.2rem;
    }

    .custom-quantity {
        display: flex;
        align-items: center;
        gap: 10px;
    }

    #qtyInput {
        width: 50px;
    }
    .custom-item-details h4{
        color: #d2d1d1;
        font-size: 34px;
        margin-bottom: 28px;
        margin-top: 26px;
        margin-left: 103px;
    }
    .p-content{
        margin-top: -3px;
        margin-left: 106px;
    }
    
</style>
</head>
<body style="background-color: #101010;">
    <uc:NavBar ID="NavBar1" runat="server" />

    <div class="container-fluid item-wrapper">
        <div class="row">

            <div class="col-lg-3">
             <uc:SideBar ID="SideBar" runat="server" />


            </div>

            <div class="col-lg-9" style="margin-left: -26px;">
               <div class="container">
                <div class="row">
                    <asp:ListView ID="lvItems" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-3 col-md-4 col-sm-6 mb-5">
                                <div class="item">
                                    <img src='<%#  Eval("image_name") %>' alt='<%# Eval("item_name") %>' />
                                    <h4 class="text-white"><%# Eval("item_name") %></h4>
                                    <p class="text-white margin"><%# Eval("description") %></p>
                                    <div class="price">Price: RS.<%# Eval("price", "{0:0.00}") %></div>
                                    <button type="button" class="add-to-cart" data-bs-toggle="modal" data-bs-target="#itemModal" 
                                            onclick="openModal('<%# Eval("item_name") %>', '<%# Eval("description") %>', '<%# Eval("price", "{0:0.00}") %>', '<%# Eval("image_name") %>')">Add to Cart</button>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
            </div>

        </div>
    </div>

  <div class="modal fade" id="itemModal" tabindex="-1" aria-labelledby="itemModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
        <div class="modal-content" style="height: 499px;">
           
            <div class="modal-body custom-modal-body" style="    background: #242424;" >
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close" style="background-color: transparent; position: absolute; top: 10px; right: 10px; filter: invert(1);">
            </button>
                <div class="custom-item-image">
                    <img id="itemImage" src='<%#  Eval("image_name") %>' alt="Item Image" style= "margin-top: 78px;">
                </div>
                <div class="custom-item-details">
                    <h4 id="itemName" class="item-head">Item Name</h4>
                    <p id="itemDescription" class="p-content">Description goes here</p>
                    <div style="margin-left: 104px; color: #FF3333; font-weight: bold;">RS. <span id="itemPrice">Price</span></div>
                    <div class="custom-quantity" style="margin-left: 106px;margin-top: 21px;">
                        <button type="button" class="btn btn-danger" style="border-radius: 0px; border: 1px solid white; background: #FF3333;     width: 38px; font-weight: bold;margin-right: -41px;" onclick="decreaseQty()">-</button>
                        <input type="text" id="qtyInput" value="1" style="background: none; border: 1px solid white; height: 37px;color: white;" class="form-control text-center" readonly>
                        <button type="button" class="btn btn-success" style="  border: 1px solid white;   border-radius: 0;    background: #FF3333; margin-left: -11px; font-weight: bold;"  onclick="increaseQty()">+</button>
                    </div>
                    <button type="button" class="btn btn-primary" style="color:white;background: #FF3333;border: none;border-radius: 0px;width: 388px;margin-left: 105px;margin-top: 42px;font-weight: bold;font-size: 18px;padding: 10px 10px 10px 10px;" onclick="addToCart()">Add to Cart</button>

                </div>
            </div>
            
        </div>
    </div>
</div>

    <!-- Login Modal -->
    <div class="modal fade" id="loginModal" tabindex="-1" aria-labelledby="loginModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="loginModalLabel">Login Required</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <p>Please log in to add items to your cart.</p>
                    <a href="Login.aspx" class="btn btn-primary">Login</a>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Success Modal -->
<div class="modal fade" id="successModal" tabindex="-1" aria-labelledby="successModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content text-center">
            <div class="modal-body">
                <img src="img/su.png" alt="Success" style="width: 100px;"/>
                <h3 class="text-success mt-3">SUCCESS!</h3>
                <p>Your item was added successfully..!</p>
                <button type="button" class="btn btn-success" data-bs-dismiss="modal">Continue Shopping</button>
            </div>
        </div>
    </div>
</div>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
    <script>
        function openModal(name, description, price, imageName) {
            document.getElementById("itemName").textContent = name;
            document.getElementById("itemDescription").textContent = description;
            document.getElementById("itemPrice").textContent = price;
            document.getElementById("itemImage").src = imageName;
            document.getElementById("qtyInput").value = 1;
            document.getElementById("errorMsg").textContent = '';
        }

        function increaseQty() {
            var qty = parseInt(document.getElementById("qtyInput").value);
            document.getElementById("qtyInput").value = qty + 1;
        }

        function decreaseQty() {
            var qty = parseInt(document.getElementById("qtyInput").value);
            if (qty > 1) {
                document.getElementById("qtyInput").value = qty - 1;
            }
        }

        function addToCart() {
            var itemName = document.getElementById("itemName").textContent;
            var qty = parseInt(document.getElementById("qtyInput").value);
            var itemPrice = document.getElementById("itemPrice").textContent;
            var itemImage = document.getElementById("itemImage").src;

            var xhr = new XMLHttpRequest();
            xhr.open("GET", "Cart.aspx?item=" + encodeURIComponent(itemName) +
                "&qty=" + qty +
                "&price=" + encodeURIComponent(itemPrice) +
                "&image=" + encodeURIComponent(itemImage), true);

            xhr.onreadystatechange = function () {
                if (xhr.readyState === 4 && xhr.status === 200) {
                    // Show success modal after item is added
                    var successModal = new bootstrap.Modal(document.getElementById('successModal'));
                    successModal.show();
                }
            };
            xhr.send();
        }
    </script>
</body>
</html>
