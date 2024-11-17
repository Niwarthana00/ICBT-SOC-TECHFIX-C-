<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="item.aspx.cs" Inherits="techfix.item" %>
<%@ Register Src="~/NavBar.ascx" TagPrefix="uc" TagName="NavBar" %>
<%@ Register Src="~/SideBar.ascx" TagPrefix="uc" TagName="SideBar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Items</title>
    <link href="css/styles.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body style="background-color: #101010;">
    <uc:SideBar ID="SideBar" runat="server" />
    <uc:NavBar ID="NavBar1" runat="server" />

    <div class="container mt-5">
        <div class="row">
            <asp:ListView ID="lvItems" runat="server">
                <ItemTemplate>
                    <div class="col-lg-3 col-md-4 col-sm-6">
                        <div class="item">
                            <img src='<%# "img/" + Eval("image_name") %>' alt='<%# Eval("item_name") %>' />
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

    <div class="modal fade" id="itemModal" tabindex="-1" aria-labelledby="itemModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="itemModalLabel">Item Details</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body custom-modal-body">
                    <div class="custom-item-image">
                        <img id="itemImage" src="" alt="Item Image">
                    </div>
                    <div class="custom-item-details">
                        <h4 id="itemName"></h4>
                        <p id="itemDescription"></p>
                        <div>RS. <span id="itemPrice"></span></div>
                        <div class="custom-quantity">
                            <button type="button" class="btn btn-danger" onclick="decreaseQty()">-</button>
                            <input type="text" id="qtyInput" value="1" class="form-control text-center" readonly>
                            <button type="button" class="btn btn-success" onclick="increaseQty()">+</button>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <span id="errorMsg" class="text-danger me-auto"></span>
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" onclick="addToCart()">Add to Cart</button>
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
            document.getElementById("itemImage").src = "img/" + imageName;
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
