Protected Sub GridView1_RowUpdating(ByVal sender As Object, _
    ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) _
    Handles GridView1.RowUpdating
    If e.NewValues("UnitPrice") IsNot Nothing Then
        e.NewValues("UnitPrice") = _
            Decimal.Parse(e.NewValues("UnitPrice").ToString(), _
            System.Globalization.NumberStyles.Currency)
    End If