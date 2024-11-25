document.getElementById("loginForm").addEventListener("submit", function (e) {
            e.preventDefault();  // Prevent form from submitting normally
        var email = document.getElementById("email").value;
        var password = document.getElementById("password").value;

        if (email && password) {
            // Simulate login process (you'll replace this with actual backend logic)
            alert("Login successful!");
        var modal = bootstrap.Modal.getInstance(document.getElementById("loginModal"));
        modal.hide();
            } else {
            alert("Please enter both email and password.");
            }
        });

    // Select all category items
    const categoryItems = document.querySelectorAll('.category-item');

    categoryItems.forEach(item => {
        item.addEventListener('click', function () {
            // Remove 'active' class from all category items
            categoryItems.forEach(i => i.classList.remove('active'));

            // Add 'active' class to the clicked category item
            this.classList.add('active');
        });
    });

    function openModal(itemName, itemDescription, itemPrice, itemImage) {
        // Set modal content dynamically
        document.getElementById("modalItemName").innerText = itemName;
    document.getElementById("modalItemDescription").innerText = itemDescription;
    document.getElementById("modalItemPrice").innerText = itemPrice;
    document.getElementById("modalItemImage").src =  itemImage;

    // Reset quantity to 1
    document.getElementById("itemQty").value = 1;

    // Show the modal
    var myModal = new bootstrap.Modal(document.getElementById("itemModal"));
    myModal.show();
    }

document.addEventListener("DOMContentLoaded", function () {
    // Initialize the quantity value
    let quantity = 1;

    // Get DOM elements
    const qtyInput = document.getElementById('itemQty');
    const increaseBtn = document.getElementById('increaseQty');
    const decreaseBtn = document.getElementById('decreaseQty');

    // Increase quantity
    increaseBtn.addEventListener('click', function () {
        quantity++;
        qtyInput.value = quantity;
    });

    // Decrease quantity
    decreaseBtn.addEventListener('click', function () {
        if (quantity > 1) {
            quantity--;
            qtyInput.value = quantity;
        }
    });
});


const track = document.querySelector('.carousel-track');
const slides = Array.from(track.children);
const dotsNav = document.querySelector('.carousel-nav');
const dots = Array.from(dotsNav.children);

const slideWidth = slides[0].getBoundingClientRect().width;

// Arrange slides next to one another
const setSlidePosition = (slide, index) => {
    slide.style.left = slideWidth * index + 'px';
};
slides.forEach(setSlidePosition);

const moveToSlide = (track, currentSlide, targetSlide) => {
    track.style.transform = 'translateX(-' + targetSlide.style.left + ')';
    currentSlide.classList.remove('current-slide');
    targetSlide.classList.add('current-slide');
};

const updateDots = (currentDot, targetDot) => {
    currentDot.classList.remove('current-dot');
    targetDot.classList.add('current-dot');
};

// Dot indicators
dotsNav.addEventListener('click', e => {
    const targetDot = e.target.closest('button');

    if (!targetDot) return;

    const currentSlide = track.querySelector('.current-slide');
    const currentDot = dotsNav.querySelector('.current-dot');
    const targetIndex = dots.findIndex(dot => dot === targetDot);
    const targetSlide = slides[targetIndex];

    moveToSlide(track, currentSlide, targetSlide);
    updateDots(currentDot, targetDot);
});
