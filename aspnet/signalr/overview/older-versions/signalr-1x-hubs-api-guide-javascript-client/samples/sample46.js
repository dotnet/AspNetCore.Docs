function init() {
    return stockTickerProxy.server.getAllStocks().done(function (stocks) {
        $.each(stocks, function () {
            var stock = this;
            console.log("Symbol=" + stock.Symbol + " Price=" + stock.Price);
        });
    }).fail(function (error) {
        console.log('Error: ' + error);
    });
}