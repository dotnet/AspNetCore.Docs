Dim productLogic As New ProductsBLL()
GridView1.DataSource = productLogic.GetProducts()
GridView1.DataBind()