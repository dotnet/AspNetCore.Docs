Imports NorthwindTableAdapters
Partial Class SuppliersAndProducts
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.Load
        Dim suppliersAdapter As New SuppliersTableAdapter
        GridView1.DataSource = suppliersAdapter.GetSuppliers()
        GridView1.DataBind()
    End Sub
End Class