// Add product data to DB.
AddProducts products = new AddProducts();
bool addSuccess = products.AddProduct(AddProductName.Text, AddProductDescription.Text,
	AddProductPrice.Text, DropDownAddCategory.SelectedValue, ProductImage.FileName);