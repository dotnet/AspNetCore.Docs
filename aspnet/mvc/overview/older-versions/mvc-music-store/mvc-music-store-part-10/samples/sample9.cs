private List<Album> GetTopSellingAlbums(int count)
 {
    // Group the order details by album and return
    // the albums with the highest count
    return storeDB.Albums
        .OrderByDescending(a => a.OrderDetails.Count())
        .Take(count)
        .ToList();
}