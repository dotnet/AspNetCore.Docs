function AppViewModel() {
    // ...

    // NEW CODE
    self.resetCart = function() {
        var items = self.cart.removeAll();
        $.each(items, function (index, product) {
            product.Quantity(0);
        });
    }

    self.getDetails = function (order) {
        self.details(new OrderDetailsViewModel(order));
    }

    self.createOrder = function () {
        var jqxhr = $.ajax({
            type: 'POST',
            url: "api/orders",
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON({ Details: self.cart }),
            dataType: "json",
            success: function (newOrder) {
                self.resetCart();
                self.orders.push(newOrder);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                self.errorMessage(errorThrown);
            }  
        });
    };
};