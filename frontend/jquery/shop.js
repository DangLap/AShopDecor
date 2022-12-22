$(document).ready(function () {
    id = window.location.search;
    id = id.substr(1);
    id = id.split("=")[1];
    if(id == undefined)
    getList(1);
    else{
    getListSearch(id)
    }
});
function getList(pageNumber){
    $.ajax({
        url: 'https://localhost:7132/api/Product?pageNumber='+pageNumber+'&pageSize=9',
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
                <div class="col-12 col-sm-6 col-lg-4">
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
            document.getElementById('listproduct').innerHTML = tabl;
        },
        fail: function (response) { }
    });
}
function getListSearch(textSearch){
    $.ajax({
        url: 'https://localhost:7132/api/Product?pageNumber=1&pageSize=9&textSearch='+textSearch,
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
                <div class="col-12 col-sm-6 col-lg-4">
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
            document.getElementById('listproduct').innerHTML = tabl;
            if(reponse.data.length < 9 ){
                document.getElementById("pageindex").style.display = "none";
            }
        },
        fail: function (response) { }
    });
}
function fillter(maxvalue){
    $.ajax({
        url: 'https://localhost:7132/api/Product/GetProductByRange?minRange=50000&maxRange='+maxvalue+'&pageNumber=1&pageSize=9',
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
                <div class="col-12 col-sm-6 col-lg-4">
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
            document.getElementById('listproduct').innerHTML = tabl;
        },
        fail: function (response) { }
    });
}