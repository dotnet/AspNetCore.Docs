protected string DisplayProductNameAndDiscontinuedStatus
    (string productName, bool discontinued)
{
    // Return just the productName if discontinued is false
    if (!discontinued)
        return productName;
    else
        // otherwise, return the productName appended with the text "[DISCONTINUED]"
        return string.Concat(productName, " [DISCONTINUED]");
}
protected string DisplayPrice(Northwind.ProductsRow product)
{
    // If price is less than $20.00, return the price, highlighted
    if (!product.IsUnitPriceNull() && product.UnitPrice < 20)
        return string.Concat("<span class=\"AffordablePriceEmphasis\">",
                              product.UnitPrice.ToString("C"), "</span>");
    else
        // Otherwise return the text, "Please call for a price quote"
        return "<span>Please call for a price quote</span>";
}