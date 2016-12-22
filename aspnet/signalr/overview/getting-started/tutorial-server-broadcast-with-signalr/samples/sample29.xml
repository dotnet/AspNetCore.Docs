$.connection.hub.start()
    .pipe(init)
    .pipe(function () {
        return ticker.server.getMarketState();
    })
    .done(function (state) {
        if (state === 'Open') {
            ticker.client.marketOpened();
        } else {
            ticker.client.marketClosed();
        }

        // Wire up the buttons
        $("#open").click(function () {
            ticker.server.openMarket();
        });

        $("#close").click(function () {
            ticker.server.closeMarket();
        });

        $("#reset").click(function () {
            ticker.server.reset();
        });
    });