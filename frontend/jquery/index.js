$(document).ready(function () {
    GetNews();
    GetHots();
    LogOut();
    document.getElementById("getsearch").addEventListener('submit', (e) => {
        e.preventDefault()
        let textsearch = document.getElementById("search").value;
        window.location.href = "shop.html??textsearch=" + textsearch;
    })
    const login = JSON.parse(localStorage.getItem('user'))
    if (login) {
        document.getElementById('uname').innerText = login.userName;
    } else {
        document.getElementById('uname').innerText = 'Đăng nhập'
    }
});
function GetNews() {
    $.ajax({
        url: 'https://localhost:7132/api/Product/GetListProductNew?pageNumber=1&pageSize=4',
        method: 'GET',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) { },
        success: function (reponse) {
            let tabl = '';
            for (var i = 0; i < reponse.data.length; ++i) {
                tien = reponse.data[i].giaBan;
                tien = tien - (tien % 1000);
                tabl = tabl + `
                <div class="col-12 col-sm-6 col-lg-3">
                    <div class="single-product-area mb-50 wow fadeInUp" data-wow-delay="200ms">
                        <div class="product-img">
                        <a href="shop-details.html??idProduct=${reponse.data[i].maSp}"><img src="assets/img/${reponse.data[i].anhDaiDien}.jpg" style="object-fit: cover;height: 255px;"></a>
                            <div class=" product-meta d-flex justify-content-center">
                                <a onclick="addtocart(${reponse.data[i].maSp})" class="add-to-cart-btn ">Thêm vào giỏ</a>
                            </div>
                        </div>
                        <div class="product-info mt-15 text-center">
                            <a href="shop-details.html">
                                <p class="content">${reponse.data[i].tenSp}</p>
                            </a>
                            <h6>${tien.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,")} ₫</h6>
                        </div>
                    </div>
                </div>
                `
            }
            document.getElementById('listnews').innerHTML = tabl;
        },
        fail: function (response) { }
    });
}
function GetHots() {
    $.ajax({
        url: 'https://localhost:7132/api/Product?pageNumber=1&pageSize=4',
        method: 'GET',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) { },
        success: function (reponse) {
            let tabl = '';
            for (var i = 0; i < reponse.data.length; ++i) {
                tien = reponse.data[i].giaBan;
                tien = tien - (tien % 1000);
                tabl = tabl + `
                <div class="col-12 col-sm-6 col-lg-3">
                    <div class="single-product-area mb-50 wow fadeInUp" data-wow-delay="200ms">
                        <div class="product-img">
                        <a href="shop-details.html??idProduct=${reponse.data[i].maSp}"><img src="assets/img/${reponse.data[i].anhDaiDien}.jpg" style="object-fit: cover;height: 255px;"></a>
                        <div class=" product-meta d-flex justify-content-center">
                        <a onclick="addtocart(${reponse.data[i].maSp})" class="add-to-cart-btn ">Thêm vào giỏ</a>
                        </div>
                        </div>
                        <div class="product-info mt-15 text-center">
                            <a href="shop-details.html">
                                <p class="content">${reponse.data[i].tenSp}</p>
                            </a>
                            <h6>${tien.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,")} ₫</h6>
                        </div>
                    </div>
                </div>
                `
            }
            document.getElementById('listhot').innerHTML = tabl;
        },
        fail: function (response) { }
    });
}
function login() {
    username = document.getElementById("username").value
    password = document.getElementById("password").value
    const url = 'https://localhost:7132/api/Account/Login?username=' + username + "&password=" + password
    console.log("url: " + url)
    $.ajax({
        url: url,
        method: 'POST',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) {
            document.getElementById('error-login').innerText = 'Tài khoản hoặc mật khẩu không chính xác!';
        },
        success: function (reponse) {
            document.getElementById('uname').innerText = reponse.userName;
            localStorage.setItem("user", JSON.stringify(reponse))
            localStorage.setItem("cartProducts", JSON.stringify(reponse.cartProducts))
            location.reload();
            LogOut();
        },
        fail: function (response) {
        }
    });
}
function addtocart(spId) {
    const login = JSON.parse(localStorage.getItem('user'))
    if (login) {
        $.ajax({
            url: 'https://localhost:7132/api/Cart/AddProductToCart?idCustomer=' + login.idUser + '&idProduct=' + spId + '&count=1',
            method: 'POST',
            contentType: 'application\json',
            dataType: 'json',
            error: function (response) { },
            success: function (reponse) {
                alert("Thêm vào giỏ hàng thành công!")
                getcart(login.idUser);
            },
            fail: function (response) { }
        });
    } else {
    //    alert("Bạn cần đăng nhập để thêm vào giỏ hàng")
    $("#exampleModal").modal();
    }
}
function getcart(iduser) {
    $.ajax({
        url: 'https://localhost:7132/api/Product/GetProductByIdUser?id=' + iduser,
        method: 'GET',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) { },
        success: function (reponse) {
            localStorage.setItem("cartProducts", JSON.stringify(reponse))
        },
        fail: function (response) { }
    });
}

function LogOut(){
    const login = JSON.parse(localStorage.getItem('user'))
    if (login){
        var obj = document.getElementById("uname");
        var obj2 = document.getElementById("logout-bar");
        obj.onmouseover = function(){
            obj2.style.display = 'block';
        }
        // obj.onmouseleave = function(){
        //     document.getElementById("logout-bar").style.display = 'none';
        // }
        obj2.onmouseover = function(){
            obj2.style.display = 'block';
        }
        obj2.onmouseleave = function(){
            obj2.style.display = 'none';
        }
        document.getElementById("btn-logout").onclick = function(){
            localStorage.clear();
            location.reload();
        }
    }

}

