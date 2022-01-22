////function OpenratorCard(val) {
////    var btnOpenrator = val;
////    var txtSL = $(btnOpenrator).parent().find("input")
////    var sl = parseInt(txtSL.val());
////    if (val.attributes["data-type"].value === "tru" && sl <= 1) // khi thao tac tru` & sl < 0
////    {
////        alert("SL không được nhỏ hơn 0!");
////        return;
////    }
////    var idSP = $(txtSL).data('id')
////    var txtTT = $("td[id=SP_" + idSP + "]");
////    var txtDG = $("td[id=DGSP_" + idSP + "]");
////    txtTT.text(txtSL.val() * txtDG.text());
////    var dssp = $('.txtSoLuong');
////    if (dssp && dssp.length > 0) {
////        var arrSp = [];
////        $.each(dssp, function (i, item) {
////            arrSp.push({
////                SoLuong: parseInt(item.value),
////                SanPham: {
////                    MaSP: $(item).data('id')
////                }
////            });
////        });
////        $.ajax({
////            url: '/GioHang/TruHang',
////            data: { cartModel: JSON.stringify(arrSp) },
////            dataType: 'json',
////            type: 'POST',
////            success: function (res) {
////                if (res.status == true) {
////                    //window.location.href = '/gio-hang';
////                }
////            }
////        });
////    }

////};
function DeleteCard(Id) {
    $.ajax({
        data: { id: Id },
        url: '/GioHang/Xoa',
        type: 'POST',
        success: function (res) {
            if (res.status == true) {
                window.location.href = '/gio-hang'
            }
        }
    })
}
function TiepTuc() {
    window.location.href = "/";
}

$(document).ready(function () {
   
    var cart = {
        init: function () {
            cart.regEvents();
        },
        regEvents: function () {
            $('#btnTiepTuc').off('click').on('click', function () {
                window.location.href = "/";
            });
            $('.btn-minus').on('click', function (e) {
                var btnMinus = e.currentTarget;
                var txtSL = $(btnMinus).parent().find("input");
                var sl = parseInt(txtSL.val());
                if (sl < 1) {
                    alert("SL không được nhỏ hơn 1!");
                    return;
                }
                var idSP = $(txtSL).data('id');
                var txtTT = $("td[id=SP_" + idSP + "]");
                var txtDG = $("td[id=DGSP_" + idSP + "]");
                txtTT.text(txtSL.val() * txtDG.text());
                var dssp = $('.txtSoLuong');
                if (dssp && dssp.length > 0) {
                    var arrSp = [];
                    $.each(dssp, function (i, item) {
                        arrSp.push({
                            SoLuong: parseInt(item.value),
                            SanPham: {
                                MaSP: $(item).data('id')
                            }
                        });
                    });
                    $.ajax({
                        url: '/GioHang/TruHang',
                        data: { cartModel: JSON.stringify(arrSp) },
                        dataType: 'json',
                        type: 'POST',
                        success: function (res) {
                            if (res.status == true) {
                                window.location.href = '/gio-hang';
                            }
                        }
                    });
                    $('#lblTongTien').text(cart.getTotal());
                }

            });
            $('.btn-plus').on('click', function (e) {
                var btnPlus = e.currentTarget;
                var txtSL = $(btnPlus).parent().find("input");
                var sl = parseInt(txtSL.val());
                var idSP = $(txtSL).data('id');
                var txtTT = $("td[id=SP_" + idSP + "]");
                var txtDG = $("td[id=DGSP_" + idSP + "]");
                txtTT.text(txtSL.val() * txtDG.text());
                var dssp = $('.txtSoLuong');
                if (dssp && dssp.length > 0) {
                    var arrSp = [];
                    $.each(dssp, function (i, item) {
                        arrSp.push({
                            SoLuong: parseInt(item.value),
                            SanPham: {
                                MaSP: $(item).data('id')
                            }
                        });
                    });
                    $.ajax({
                        url: '/GioHang/CongHang',
                        data: { cartModel: JSON.stringify(arrSp) },
                        dataType: 'json',
                        type: 'POST',
                        success: function (res) {
                            if (res.status == true) {
                                window.location.href = '/gio-hang';
                            }
                        }
                    });
                   
                }

            });
          
        },
     

    }
    cart.init();
});



//================
//$('.drop').on('change',function () {
//    $('#txtSumDiscount').text('0');
//    $('#txtSumPrice').text('0');
//    $('#txtTotal').text('0');
//    var tr = $(this).closest('tr');
//    var price = $(tr).find('.ffour').html() - $(tr).find('.fthree').html();
//    $(tr).find('.fone').html(price * $(this).val());

//    var sum = 0, discount = 0, total =0;

//    $(this).closest('#dvCart').find('tr td.fone').each(function(){
//        var parent = $(this).parent();
//        var q = parseFloat($(parent).find('select.drop').val());
//        sum += parseFloat($(parent).find('td.ffour').text()) * q;
//        discount += parseFloat($(parent).find('td.fthree').text()) * q;
//    });

//    $('#txtSumPrice').html(sum);
//    $('#txtSumDiscount').html(discount);
//    $('#txtTotal').html(sum - discount);
//});
