namespace ProductServiceClient.ProductService
{
    public partial class Container
    {
        public double RateProduct(int productID, int rating)
        {
            Uri actionUri = new Uri(this.BaseUri,
                String.Format("Products({0})/RateProduct", productID)
                );

            return this.Execute<double>(actionUri, 
                "POST", true, new BodyOperationParameter("Rating", rating)).First();
        }
    }
}