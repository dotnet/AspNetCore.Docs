var stocks = await stockTickerHub.Invoke<IEnumerable<Stock>>("AddStock", new Stock() { Symbol = "MSFT" });
foreach (Stock stock in stocks)
{
    textBox.Text += string.Format("Symbol: {0} price: {1}\n", stock.Symbol, stock.Price);
}