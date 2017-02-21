Protected Sub GridView1_RowUpdating(sender As Object, e As GridViewUpdateEventArgs) _
    Handles GridView1.RowUpdating
    If e.NewValues("UnitPrice") IsNot Nothing Then
        e.NewValues("UnitPrice") = _
            Decimal.Parse(e.NewValues("UnitPrice").ToString(), _
                System.Globalization.NumberStyles.Currency)
    End If
End Sub