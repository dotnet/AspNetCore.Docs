private void UpdateProductImage(Product product)
{
	string imageUrl = product.ImagePath;

	if (!string.IsNullOrEmpty(imageUrl) && !VirtualPathUtility.IsAbsolute(imageUrl))
	{
		product.ImagePath = string.Format(
								 "/Images/{0}{1}", 
								 product.ProductId, 
								 Path.GetExtension(imageUrl));

		using (var wc = new WebClient())
		{
			wc.DownloadFile(imageUrl, Server.MapPath(product.ImagePath));
		}
	}
}