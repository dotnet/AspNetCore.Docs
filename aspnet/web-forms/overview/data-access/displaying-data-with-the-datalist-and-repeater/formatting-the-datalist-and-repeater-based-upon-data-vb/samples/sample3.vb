Protected Function DisplayProductNameAndDiscontinuedStatus _
    (productName As String, discontinued As Boolean) As String
    ' Return just the productName if discontinued is false
    If Not discontinued Then
        Return productName
    Else
        ' otherwise, return the productName appended with the text "[DISCONTINUED]"
        Return String.Concat(productName, " [DISCONTINUED]")
    End If
End Function
Protected Function DisplayPrice(product As Northwind.ProductsRow) As String
    ' If price is less than $20.00, return the price, highlighted
    If Not product.IsUnitPriceNull() AndAlso product.UnitPrice < 20 Then
        Return String.Concat("<span class="AffordablePriceEmphasis">", _
                             product.UnitPrice.ToString("C"), "</span>")
    Else
        ' Otherwise return the text, "Please call for a price quote"
        Return "<span>Please call for a price quote</span>"
    End If
End Function