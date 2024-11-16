// Giỏ hàng (Cart) - Sử dụng localStorage để lưu giỏ hàng
let cart = JSON.parse(localStorage.getItem('cart')) || [];

// Hàm để thêm sản phẩm vào giỏ hàng
function addToCart(productName, price) {
    // Kiểm tra nếu sản phẩm đã có trong giỏ hàng
    const existingProductIndex = cart.findIndex(item => item.name === productName);

    if (existingProductIndex >= 0) {
        // Nếu sản phẩm đã có trong giỏ, tăng số lượng lên
        cart[existingProductIndex].quantity += 1;
    } else {
        // Nếu sản phẩm chưa có trong giỏ, thêm sản phẩm mới
        const product = {
            name: productName,
            price: price,
            quantity: 1
        };
        cart.push(product);
    }

    // Lưu lại giỏ hàng vào localStorage
    localStorage.setItem('cart', JSON.stringify(cart));
    renderCart();
}

// Hàm để hiển thị giỏ hàng
function renderCart() {
    const cartItemsContainer = document.getElementById('cart-items');
    cartItemsContainer.innerHTML = '';  // Xóa nội dung cũ

    if (cart.length === 0) {
        cartItemsContainer.innerHTML = '<p>Your cart is empty.</p>';
    } else {
        // Hiển thị các sản phẩm trong giỏ hàng
        cart.forEach(item => {
            const cartItem = document.createElement('div');
            cartItem.classList.add('cart-item');
            cartItem.innerHTML = `
                <p><strong>${item.name}</strong></p>
                <p>Price: $${item.price}</p>
                <p>Quantity: ${item.quantity}</p>
                <p>Total: $${item.price * item.quantity}</p>
            `;
            cartItemsContainer.appendChild(cartItem);
        });

        // Thêm tổng giá trị của giỏ hàng
        const total = cart.reduce((sum, item) => sum + item.price * item.quantity, 0);
        const totalElement = document.createElement('p');
        totalElement.innerHTML = `<strong>Total: $${total}</strong>`;
        cartItemsContainer.appendChild(totalElement);
    }
}

// Hàm để xử lý checkout
function checkout() {
    if (cart.length === 0) {
        alert("Your cart is empty. Please add some items to the cart.");
    } else {
        alert("Proceeding to checkout...");
        // Xử lý thanh toán ở đây (ví dụ: chuyển hướng đến trang thanh toán)
    }
}

// Hàm xử lý form tìm kiếm cá Koi
document.getElementById('search-form').addEventListener('submit', function (e) {
    e.preventDefault();

    const farm = document.getElementById('farm').value;
    const koiType = document.getElementById('koi-type').value;
    const priceRange = document.getElementById('price-range').value;
    const date = document.getElementById('date').value;

    // Thực hiện tìm kiếm cá Koi theo tiêu chí (có thể gửi yêu cầu tìm kiếm đến máy chủ)
    alert(`Searching Koi Fish: Farm = ${farm}, Type = ${koiType}, Price Range = ${priceRange}, Date = ${date}`);
});

// Render giỏ hàng khi tải trang
renderCart();
