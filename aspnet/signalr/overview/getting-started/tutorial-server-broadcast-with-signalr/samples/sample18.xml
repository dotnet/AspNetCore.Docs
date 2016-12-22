ticker.client.updateStockPrice = function (stock) {
    var displayStock = formatStock(stock),
        $row = $(rowTemplate.supplant(displayStock));

    $stockTableBody.find('tr[data-symbol=' + stock.Symbol + ']')
        .replaceWith($row);
    }