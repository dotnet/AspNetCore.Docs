var stocks = stockTickerHub.Invoke<IEnumerable<Stock>>("AddStock", new Stock() { Symbol = "MSFT" }).Result;
foreach (Stock stock in stocks)
{
    textBox.Text += string.Format("Symbol: {0} price: {1}\n", stock.Symbol, stock.Price);
}