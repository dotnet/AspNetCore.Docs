public static class RecommendationEngine
{
   private static List<string> MenCategoies = new List<string>()
        {
            "mens-clothes",
            "mens-bags",
            "mens-shoes",
            "mens-grooming"
        };

   private static List<string> WomenCategoies = new List<string>()
        {
            "womens-clothes",
            "handbags",
            "womens-shoes",
            "womens-beauty"
        };

   public static async Task<List<Product>> RecommendProductAsync(MyAppUserFriend friend)
   {
      List<Product> recommendedItems = new List<Product>();
      List<string> categoryBasedOnGender = WomenCategoies;

      if (friend.Gender == "male")
      {
         categoryBasedOnGender = MenCategoies;
      }

      foreach (var item in categoryBasedOnGender)
      {
         var result = await ShoppingSearchClient.GetProductsAsync(item);
         //Randomly pick an item from the retrieved items
         Random r = new Random();
         var product = result.Products[r.Next(result.Products.Count())];
         var des = product.Description;
         //Remove html elements from Product Description
         string noHTML = Regex.Replace(product.Description, @"<[^>]+>|&nbsp;", "").Trim();
         product.Description = Regex.Replace(noHTML, @"\s{2,}", " ");
         recommendedItems.Add(product);
      }

      return recommendedItems;
   }
}