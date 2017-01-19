// Highlight the product name and unit price Labels
// First, get a reference to the two Label Web controls
Label ProductNameLabel = (Label)e.Item.FindControl("ProductNameLabel");
Label UnitPriceLabel = (Label)e.Item.FindControl("UnitPriceLabel");
// Next, set their CssClass properties
if (ProductNameLabel != null)
    ProductNameLabel.CssClass = "AffordablePriceEmphasis";
if (UnitPriceLabel != null)
    UnitPriceLabel.CssClass = "AffordablePriceEmphasis";