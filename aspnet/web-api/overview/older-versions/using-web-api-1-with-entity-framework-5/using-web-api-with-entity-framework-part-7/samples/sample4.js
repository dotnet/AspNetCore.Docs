function AppViewModel() {
    // ...

    // NEW CODE
    function ProductViewModel(root, product) {
        var self = this;
        self.ProductId = product.Id;
        self.Name = product.Name;
        self.Price = product.Price;
        self.Quantity = ko.observable(0);

        self.addItemToCart = function () {
            var qty = self.Quantity();
            if (qty == 0) {
                root.cart.push(self);
            }
            self.Quantity(qty + 1);
        };

        self.removeAllFromCart = function () {
            self.Quantity(0);
            root.cart.remove(self);
        };
    }
}