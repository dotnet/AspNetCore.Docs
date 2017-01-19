function scrollTicker() {
    var w = $stockTickerUl.width();
    $stockTickerUl.css({ marginLeft: w });
    $stockTickerUl.animate({ marginLeft: -w }, 15000, 'linear', scrollTicker);
}