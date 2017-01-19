Protected Sub SortPriceDescending_Click(sender As Object, e As System.EventArgs) _
    Handles SortPriceDescending.Click
        'Sort by UnitPrice in descending order
        Products.Sort("UnitPrice", SortDirection.Descending)
End Sub