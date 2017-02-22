ProductsBLL productLogic = new ProductsBLL();
GridView1.DataSource = productLogic.GetProducts();
GridView1.DataBind();