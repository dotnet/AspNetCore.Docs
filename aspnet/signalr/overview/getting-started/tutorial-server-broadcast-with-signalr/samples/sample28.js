$.extend(ticker.client, {
    updateStockPrice: function (stock) {
        var displayStock = formatStock(stock),
            $row = $(rowTemplate.supplant(displayStock)),
            $li = $(liTemplate.supplant(displayStock)),
            bg = stock.LastChange === 0
                ? '255,216,0' // yellow
                : stock.LastChange > 0
                    ? '154,240,117' // green
                    : '255,148,148'; // red

        $stockTableBody.find('tr[data-symbol=' + stock.Symbol + ']')
            .replaceWith($row);
        $stockTickerUl.find('li[data-symbol=' + stock.Symbol + ']')
            .replaceWith($li);

        $row.flash(bg, 1000);
        $li.flash(bg, 1000);
    },

    marketOpened: function () {
        $("#open").prop("disabled", true);
        $("#close").prop("disabled", false);
        $("#reset").prop("disabled", true);
        scrollTicker();
    },

    marketClosed: function () {
        $("#open").prop("disabled", false);
        $("#close").prop("disabled", true);
        $("#reset").prop("disabled", false);
        stopTicker();
    },

    marketReset: function () {
        return init();
    }
});