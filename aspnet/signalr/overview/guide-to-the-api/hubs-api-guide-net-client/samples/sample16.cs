public void BroadcastStockPrice(Stock stock)
{
    context.Clients.Others.UpdateStockPrice(stock);
}