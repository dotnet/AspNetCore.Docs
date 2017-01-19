Dim productsAdapter As New ProductsTableAdapter()
GridView1.DataSource = productsAdapter.GetProducts()
GridView1.DataBind()