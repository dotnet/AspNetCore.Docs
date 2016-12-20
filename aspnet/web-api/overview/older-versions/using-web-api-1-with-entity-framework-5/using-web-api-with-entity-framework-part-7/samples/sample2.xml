function AppViewModel() {
    // ...

    // NEW CODE
    function OrderDetailsViewModel(order) {
        var self = this;
        self.items = ko.observableArray();
        self.Id = order.Id;

        self.total = ko.computed(function () {
            var sum = 0;
            $.each(self.items(), function (index, item) {
                sum += item.Price * item.Quantity;
            });
            return '$' + sum.toFixed(2);
        });

        $.getJSON("/api/orders/" + order.Id, function (order) {
            $.each(order.Details, function (index, item) {
                self.items.push(item);
            })
        });
    };
}