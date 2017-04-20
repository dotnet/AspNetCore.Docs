Dim suppliersAdapter As New NorthwindTableAdapters.SuppliersTableAdapter()
Dim suppliers As Northwind.SuppliersDataTable = suppliersAdapter.GetSuppliers()
For Each supplier As Northwind.SuppliersRow In suppliers
    Response.Write("Supplier: " & supplier.CompanyName)
    Response.Write("<ul>")
    Dim products As Northwind.ProductsDataTable = supplier.GetProducts()
    For Each product As Northwind.ProductsRow In products
        Response.Write("<li>" & product.ProductName & "</li>")
    Next
    Response.Write("</ul><p> </p>")
Next