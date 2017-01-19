' Highlight the product name and unit price Labels
' First, get a reference to the two Label Web controls
Dim ProductNameLabel As Label = CType(e.Item.FindControl("ProductNameLabel"), Label)
Dim UnitPriceLabel As Label = CType(e.Item.FindControl("UnitPriceLabel"), Label)
' Next, set their CssClass properties
If ProductNameLabel IsNot Nothing Then
    ProductNameLabel.CssClass = "AffordablePriceEmphasis"
End If
If UnitPriceLabel IsNot Nothing Then
    UnitPriceLabel.CssClass = "AffordablePriceEmphasis"
End If