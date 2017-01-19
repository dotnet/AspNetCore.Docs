Public Function TotalNumberOfProducts() As Integer
    Return Adapter.TotalNumberOfProducts().GetValueOrDefault()
End Function