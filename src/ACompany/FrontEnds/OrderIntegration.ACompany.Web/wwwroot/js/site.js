function orderDelivered(orderId) {
    if (confirm('Siparişin Statüsü Teslim Edildi Olarak Değiştirilecektir. Emin Misiniz?')) {
        $.ajax({
            url: "/OrderManagement/Delivered/" + orderId,
            type: "GET",
            success: function (response) {
                if (response.isSuccessful) {
                    alert("Teslim edildi olarak güncellendi!");
                    $('.order-record[data-id="' + response.id + '"]').remove();
                }
                else {
                    alert(response.error);
                }

            },
            error: function (xhr, status, error) {
                alert("Bir hata oluştu: " + error);
            }
        });
    }
    
}