protected string DisplayPrice(object unitPrice)
{
    // If price is less than $20.00, return the price, highlighted
    if (!Convert.IsDBNull(unitPrice) && ((decimal) unitPrice) < 20)
        return string.Concat("<span class=\"AffordablePriceEmphasis\">",
                              ((decimal) unitPrice).ToString("C"), "</span>");
    else
        // Otherwise return the text, "Please call for a price quote"
        return "<span>Please call for a price quote</span>";
}