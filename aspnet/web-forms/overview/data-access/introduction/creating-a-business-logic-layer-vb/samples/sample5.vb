Imports System.data

Partial Public Class Northwind
    Partial Public Class ProductsDataTable
        Public Overrides Sub BeginInit()
            AddHandler Me.ColumnChanging, AddressOf ValidateColumn
        End Sub

        Sub ValidateColumn(sender As Object, e As DataColumnChangeEventArgs)
            If e.Column.Equals(Me.UnitPriceColumn) Then
                If Not Convert.IsDBNull(e.ProposedValue) AndAlso _
                    CType(e.ProposedValue, Decimal) < 0 Then
                    Throw New ArgumentException( _
                        "UnitPrice cannot be less than zero", "UnitPrice")
                End If
            ElseIf e.Column.Equals(Me.UnitsInStockColumn) OrElse _
                e.Column.Equals(Me.UnitsOnOrderColumn) OrElse _
                e.Column.Equals(Me.ReorderLevelColumn) Then
                If Not Convert.IsDBNull(e.ProposedValue) AndAlso _
                    CType(e.ProposedValue, Short) < 0 Then
                    Throw New ArgumentException(String.Format( _
                        "{0} cannot be less than zero", e.Column.ColumnName), _
                        e.Column.ColumnName)
                End If
            End If
        End Sub
    End Class
End Class