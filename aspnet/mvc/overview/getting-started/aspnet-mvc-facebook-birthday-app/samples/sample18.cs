namespace SampleFacebookBirthdayApp.Models
{
    public class SearchResult
    {
        public Product[] Products { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ClickUrl { get; set; }

        public ProductImage Image { get; set; }

        public string PriceLabel { get; set; }
    }

    public class ProductImage
    {
        public Sizes Sizes { get; set; }
    }

    public class Sizes
    {
        public BestImage Large { get; set; }
    }

    public class BestImage
    {
        public string Height {get; set;}

        public string Url {get; set;}

        public string Width {get; set;}
    }
}