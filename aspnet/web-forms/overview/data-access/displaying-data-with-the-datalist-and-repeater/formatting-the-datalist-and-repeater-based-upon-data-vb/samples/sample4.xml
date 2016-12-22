Protected Function DisplayPrice(ByVal unitPrice As Object) As String
    ' If price is less than $20.00, return the price, highlighted
    If Not Convert.IsDBNull(unitPrice) AndAlso CType(unitPrice, Decimal) < 20 Then
        Return String.Concat("<span class="AffordablePriceEmphasis">", _
            CType(unitPrice, Decimal).ToString("C"), "</span>")
    Else
        ' Otherwise return the text, "Please call for a price quote"
        Return "<span>Please call for a price quote</span>"
    End If
End Function