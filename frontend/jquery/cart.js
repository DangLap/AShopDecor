$(document).ready(function () {
    closePopUp();
    checkOut();
    listProducts = JSON.parse(localStorage.getItem('cartProducts'))
    if (listProducts) {
        getProductToCart();
        sumThanhToan();
    } else {

    }
});
function getProductToCart() {
    listProducts = JSON.parse(localStorage.getItem('cartProducts'))
    let showlist = '';
    for (var i = 0; i < listProducts.length; i++) {
        showlist += `
    <tr>
                                    <td class="cart_product_img">
                                        <a href="#"><img src="assets/img/${listProducts[i].anhDaiDien}.jpg" alt="Product"></a>
                                        <h5>${listProducts[i].tenSp}</h5>
                                    </td>
                                    <td class="qty">
                                        <div class="quantity">
                                            <span class="qty-minus" onclick="var effect = document.getElementById('qty${i}'); var qty = effect.value; if( !isNaN( qty ) &amp;&amp; qty &gt; 1 ) effect.value--;changecount(${i},${listProducts[i].giaBan});return false;"><i class="fa fa-minus" aria-hidden="true"></i></span>
                                            <input type="number" class="qty-text" id="qty${i}" step="1" min="1" max="99" name="quantity" value="${listProducts[i].soLuong}" onchange="changecount(${i},${listProducts[i].giaBan})">
                                            <span class="qty-plus" onclick="var effect = document.getElementById('qty${i}'); var qty = effect.value; if( !isNaN( qty )) effect.value++;changecount(${i},${listProducts[i].giaBan});return false;"><i class="fa fa-plus" aria-hidden="true"></i></span>
                                        </div>
                                    </td>
                                    <td class="price"><span>${listProducts[i].giaBan.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,")} ₫</span></td>
                                    <td class="total_price" id="sum${i}"><span>${listProducts[i].giaBan.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,")} ₫</span></td>
                                    <td class="action"><div onclick ="deleteItem(${listProducts[i].maSp})"><i class="icon_close"></i></div></td>
                                </tr>
    `
    }
    document.getElementById("productList").innerHTML = showlist;
}
function changecount(i, giaBan) {
    listProducts = JSON.parse(localStorage.getItem('cartProducts'));
    listProducts[i].soLuong = (document.getElementById('qty' + i).value);
    localStorage.setItem("cartProducts", JSON.stringify(listProducts));
    sumThanhToan()
    let gia = ''
    gia += (document.getElementById('qty' + i).value) * giaBan
    document.getElementById('sum' + i).innerHTML = gia.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,") + " ₫";
}
function deleteItem(idproduct) {

    const user = JSON.parse(localStorage.getItem('user'))
    if (user) {
        idUser = user.idUser;
        var token = user.token
        console.log("token", token)
        $.ajax({
            url: 'https://localhost:7132/api/Cart/DeleteProductToCart?idUser=' + idUser + "&idProduct=" + idproduct,
            method: 'DELETE',
            headers: {
                Authorization: 'Bearer ' + token
            },
            contentType: 'application\json',
            dataType: 'json',
            error: function (response) { },
            success: function (reponse) {
                listProducts = JSON.parse(localStorage.getItem('cartProducts'))
                for (var i = 0; i < listProducts.length; i++) {
                    if (listProducts[i].maSp == idproduct) {
                        listProducts.splice(i, 1)
                        localStorage.setItem("cartProducts", JSON.stringify(listProducts))
                    }
                }
                getProductToCart()
                sumThanhToan()
            },
            fail: function (response) { }
        });
    } else {

    }
}
function sumThanhToan(){
    listProducts = JSON.parse(localStorage.getItem('cartProducts'));
    let sum = 0;
    for(var i=0;i< listProducts.length;i++){
        sum += listProducts[i].soLuong * listProducts[i].giaBan;

    }
    document.getElementById("totalPrice").innerHTML = sum.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,") + " ₫";
}
function closePopUp(){
    document.getElementById("btn-close").onclick = function(){
        document.getElementById("pop-up-container").style.visibility = 'hidden';
        callapiThanhtoan()

    }
}
function checkOut(){
    document.getElementById("checkout-button").onclick = function(){
        listProducts = JSON.parse(localStorage.getItem('cartProducts'))
    if (listProducts) {
        localStorage.setItem("cartProducts", JSON.stringify([]))
        document.getElementById("pop-up-container").style.visibility = 'visible';
    } else {

    }
       
    }
}
function callapiThanhtoan(){
    const user = JSON.parse(localStorage.getItem('user'))
    $.ajax({
        url: 'https://localhost:7132/api/Cart/CheckoutCart?userId=' + user.idUser,
        method: 'POST',
        contentType: 'application\json',
        dataType: 'json',
        error: function (response) { },
        success: function (reponse) {
            location.reload()

        },
        fail: function (response) { }
    });
}