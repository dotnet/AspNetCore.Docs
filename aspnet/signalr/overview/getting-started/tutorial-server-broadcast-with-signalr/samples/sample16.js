function init() {
    ticker.server.getAllStocks().done(function (stocks) {
        $stockTableBody.empty();
        $.each(stocks, function () {
            var stock = formatStock(this);
            $stockTableBody.append(rowTemplate.supplant(stock));
        });
    });
}