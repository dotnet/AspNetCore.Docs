public void SaveCustomer(Customer customer) 
{
	if (this.ModelState.IsValid)
	{ 
		using (var db = new ProductsContext())
		{
			...