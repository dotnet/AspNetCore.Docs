protected void FilterProducts(object sender, CustomExpressionEventArgs e) 
{ 
	e.Query = from p in e.Query.Cast() 
	  where p.UnitPrice >= 10 
	  select p; 
}