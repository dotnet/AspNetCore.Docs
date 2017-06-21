int rating = 2;
Uri actionUri = new Uri(uri, "Products(5)/RateProduct");
var averageRating = container.Execute<double>(
    actionUri, "POST", true, new BodyOperationParameter("Rating", rating)).First();