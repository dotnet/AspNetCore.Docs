public bool AddProduct(string ProductName, string ProductDesc, string ProductPrice, string ProductCategory, string ProductImagePath)
{
	var myProduct = new Product();
	myProduct.ProductName = ProductName;
	myProduct.Description = ProductDesc;
	myProduct.UnitPrice = Convert.ToDouble(ProductPrice);
	myProduct.ImagePath = ProductImagePath;
	myProduct.CategoryID = Convert.ToInt32(ProductCategory);

	using (ProductContext _db = new ProductContext())
	{
		// Add product to DB.
		_db.Products.Add(myProduct);
		try
		{
			_db.SaveChanges();
		}
		catch (RetryLimitExceededException ex)
		{
			// Log the RetryLimitExceededException.
			WingtipToys.Logic.ExceptionUtility.LogException(ex, "Error: RetryLimitExceededException -> RemoveProductButton_Click in AdminPage.aspx.cs");
		}
	}
	// Success.
	return true;
}