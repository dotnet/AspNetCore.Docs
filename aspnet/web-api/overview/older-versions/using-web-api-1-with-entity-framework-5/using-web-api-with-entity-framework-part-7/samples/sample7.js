function AppViewModel() {
    // ...

    // NEW CODE
    // Initialize the view-model.
    $.getJSON("/api/products", function (products) {
        $.each(products, function (index, product) {
            self.products.push(new ProductViewModel(self, product));
        })
    });

    $.getJSON("api/orders", self.orders);
};