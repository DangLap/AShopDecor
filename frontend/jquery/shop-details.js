$(document).ready(function () {

    id = window.location.search;
    id = id.substr(1);
    id = id.split("=")[1];
    $.ajax({

        url: 'https://localhost:7132/api/Product/' + id,
        method: 'GET',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) {
            console.log('loi')
        },
        success: function (reponse) {
            tien = reponse.giaBan;
            tien = tien - (tien % 1000);
            SanPhamTuongTu(reponse.maLsp);
            let img = '';
            img = img + ` 
        <div class="produts-details--content mb-50">
            <div class="container">
                <div class="row justify-content-between">

                    <div class="col-12 col-md-6 col-lg-5">
                        <div class="single_product_thumb">
                            <div id="product_details_slider" class="carousel slide" data-ride="carousel">
                                <div class="carousel-inner" style="max-height:440px" id="imagedetail">
                                   
                                </div>
                                <ol class="carousel-indicators" id = "iconimg">
                                   
                                </ol>
                            </div>
                        </div>
                    </div>

                    <div class="col-12 col-md-6">
                        <div class="single_product_desc">
                            <h4 class="title">${reponse.tenSp}</h4>
                            <h4 class="price">${tien.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,")} ₫</h4>
                            <div class="short_overview">
                                <p>${reponse.moTa}</p>
                            </div>

                            <div class="cart--area d-flex flex-wrap align-items-center">
                                <!-- Add to Cart Form -->
                                <form class="cart clearfix d-flex align-items-center" method="post">
                                    <div class="quantity">
                                        <span class="qty-minus" onclick="var effect = document.getElementById('qty'); var qty = effect.value; if( !isNaN( qty ) &amp;&amp; qty &gt; 1 ) effect.value--;return false;"><i class="fa fa-minus" aria-hidden="true"></i></span>
                                        <input type="number" class="qty-text" id="qty" step="1" min="1" max="12" name="quantity" value="1">
                                        <span class="qty-plus" onclick="var effect = document.getElementById('qty'); var qty = effect.value; if( !isNaN( qty )) effect.value++;return false;"><i class="fa fa-plus" aria-hidden="true"></i></span>
                                    </div>
                                    <a onclick="addtocart(${reponse.maSp})" name="addtocart" value="5" class="btn alazea-btn ml-15">Thêm vào giỏ hàng</a>
                                </form>
                               
                            </div>

                            <div class="products--meta">
                                <p><span>Số lượng còn:</span> <span>${reponse.sltonHienTai}</span></p>
                                <p><span>Màu:</span> <span>đen, trắng </span></p>
                                <p>
                                    <span>Chia sẻ:</span>
                                    <span>
                                    <a href="#"><i class="fa fa-facebook"></i></a>
                                    <a href="#"><i class="fa fa-twitter"></i></a>
                                    <a href="#"><i class="fa fa-pinterest"></i></a>
                                    <a href="#"><i class="fa fa-google-plus"></i></a>
                                </span>
                                </p>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="product_details_tab clearfix">
                        <!-- Tabs -->
                        <ul class="nav nav-tabs" role="tablist" id="product-details-tab">
                            <li class="nav-item">
                                <a href="#description" class="nav-link active" data-toggle="tab" role="tab">Mô tả</a>
                            </li>
                            <li class="nav-item">
                                <a href="#addi-info" class="nav-link" data-toggle="tab" role="tab">Additional Information</a>
                            </li>
                            <li class="nav-item">
                                <a href="#reviews" class="nav-link" data-toggle="tab" role="tab">Reviews <span class="text-muted">(1)</span></a>
                            </li>
                        </ul>
                        <!-- Tab Content -->
                        <div class="tab-content">
                            <div role="tabpanel" class="tab-pane fade show active" id="description">
                                <div class="description_area">
                                <p>${reponse.moTa}</p>    
                                </div>
                            </div>
                            <div role="tabpanel" class="tab-pane fade" id="addi-info">
                                <div class="additional_info_area">
                                    <p>What should I do if I receive a damaged parcel?
                                        <br> <span>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reprehenderit impedit similique qui, itaque delectus labore.</span></p>
                                    <p>I have received my order but the wrong item was delivered to me.
                                        <br> <span>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Facilis quam voluptatum beatae harum tempore, ab?</span></p>
                                    <p>Product Receipt and Acceptance Confirmation Process
                                        <br> <span>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Dolorum ducimus, temporibus soluta impedit minus rerum?</span></p>
                                    <p>How do I cancel my order?
                                        <br> <span>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Nostrum eius eum, minima!</span></p>
                                </div>
                            </div>
                            <div role="tabpanel" class="tab-pane fade" id="reviews">
                                <div class="reviews_area">
                                    <ul>
                                        <li>
                                            <div class="single_user_review mb-15">
                                                <div class="review-rating">
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <span>for Quality</span>
                                                </div>
                                                <div class="review-details">
                                                    <p>by <a href="#">Colorlib</a> on <span>12 Sep 2018</span></p>
                                                </div>
                                            </div>
                                            <div class="single_user_review mb-15">
                                                <div class="review-rating">
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <span>for Design</span>
                                                </div>
                                                <div class="review-details">
                                                    <p>by <a href="#">Colorlib</a> on <span>12 Sep 2018</span></p>
                                                </div>
                                            </div>
                                            <div class="single_user_review">
                                                <div class="review-rating">
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <i class="fa fa-star" aria-hidden="true"></i>
                                                    <span>for Value</span>
                                                </div>
                                                <div class="review-details">
                                                    <p>by <a href="#">Colorlib</a> on <span>12 Sep 2018</span></p>
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </div>

                                <div class="submit_a_review_area mt-50">
                                    <h4>Submit A Review</h4>
                                    <form action="#" method="post">
                                        <div class="row">
                                            <div class="col-12">
                                                <div class="form-group d-flex align-items-center">
                                                    <span class="mr-15">Your Ratings:</span>
                                                    <div class="stars">
                                                        <input type="radio" name="star" class="star-1" id="star-1">
                                                        <label class="star-1" for="star-1">1</label>
                                                        <input type="radio" name="star" class="star-2" id="star-2">
                                                        <label class="star-2" for="star-2">2</label>
                                                        <input type="radio" name="star" class="star-3" id="star-3">
                                                        <label class="star-3" for="star-3">3</label>
                                                        <input type="radio" name="star" class="star-4" id="star-4">
                                                        <label class="star-4" for="star-4">4</label>
                                                        <input type="radio" name="star" class="star-5" id="star-5">
                                                        <label class="star-5" for="star-5">5</label>
                                                        <span></span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-12 col-md-6">
                                                <div class="form-group">
                                                    <label for="name">Nickname</label>
                                                    <input type="email" class="form-control" id="name" placeholder="Nazrul">
                                                </div>
                                            </div>
                                            <div class="col-12 col-md-6">
                                                <div class="form-group">
                                                    <label for="options">Reason for your rating</label>
                                                    <select class="form-control" id="options">
                                                          <option>Quality</option>
                                                          <option>Value</option>
                                                          <option>Design</option>
                                                          <option>Price</option>
                                                          <option>Others</option>
                                                    </select>
                                                </div>
                                            </div>
                                            <div class="col-12">
                                                <div class="form-group">
                                                    <label for="comments">Comments</label>
                                                    <textarea class="form-control" id="comments" rows="5" data-max-length="150"></textarea>
                                                </div>
                                            </div>
                                            <div class="col-12">
                                                <button type="submit" class="btn alazea-btn">Submit Your Review</button>
                                            </div>
                                        </div>
                                    </form>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
            `
            document.getElementById('detail-product').innerHTML = img;
            let img_detail = '';
            let icon_img = '';
            for(var i=0;i<reponse.lstImage.length;i++){
                img_detail += `
                <div class="carousel-item ${i==0? "active" : ""}">
                    <a class="product-img" href="assets/img/${reponse.lstImage[i]}.jpg" title="Product Image">
                    <img class="d-block w-100" src="assets/img/${reponse.lstImage[i]}.jpg" alt="1">
                </a>
                </div>
                `
                icon_img += `
                <li class="${i==0? "active" : ""}" data-target="#product_details_slider" data-slide-to="${i}" style="background-image: url(assets/img/${reponse.lstImage[i]}.jpg);">
                                    </li>
                `
            }
            document.getElementById('imagedetail').innerHTML = img_detail;
            document.getElementById('iconimg').innerHTML = icon_img;
        },
        fail: function (response) { }
    });
});
function SanPhamTuongTu(maloai){
    $.ajax({
        url: 'https://localhost:7132/api/Product/GetProductByCategory?id='+ maloai+ '&pageNumber=1&pageSize=4',
        method: 'GET',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) { },
        success: function (reponse) {
            let tabl = '';
            for (var i = 0; i < reponse.data.length; ++i) {
                tien = reponse.data[i].giaBan;
                tien = tien - (tien%1000);
                tabl = tabl + `
                <div class="col-12 col-sm-6 col-lg-3">
                    <div class="single-product-area mb-50 wow fadeInUp" data-wow-delay="200ms">
                        <div class="product-img">
                        <a href="shop-details.html??idProduct=${reponse.data[i].maSp}"><img src="assets/img/${reponse.data[i].anhDaiDien}.jpg" style="object-fit: cover;height: 255px;"></a>
                        <div class=" product-meta d-flex justify-content-center">
                                <a onclick="addtocart(${reponse.data[i].maSp})" class="add-to-cart-btn ">Thêm vào giỏ </a>
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
            document.getElementById('sptuongtu').innerHTML = tabl;
        },
        fail: function (response) { }
    });
}