Private ReadOnly Property TotalRowCount() As Integer
    Get
        'Return the value from the TotalNumberOfProducts() method
        Dim productsAPI As New ProductsBLL()
        Return productsAPI.TotalNumberOfProducts()
    End Get
End Property