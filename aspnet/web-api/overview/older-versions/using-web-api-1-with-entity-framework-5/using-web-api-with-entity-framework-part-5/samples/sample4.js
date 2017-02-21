function ProductsViewModel() {
    var self = this;
    self.products = ko.observableArray();

    // New code
    var baseUri = '@ViewBag.ApiUrl';
    $.getJSON(baseUri, self.products);
}