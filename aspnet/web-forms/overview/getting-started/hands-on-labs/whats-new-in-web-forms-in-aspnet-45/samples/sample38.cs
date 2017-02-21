private void UpdateProductImage(Product product)
{
	string imageUrl = product.ImagePath;

	if (!string.IsNullOrEmpty(imageUrl) && !VirtualPathUtility.IsAbsolute(imageUrl))
	{
		product.ImagePath = string.Format(
			"/Images/{0}{1}", 
			product.ProductId, 
			Path.GetExtension(imageUrl));

		this.RegisterAsyncTask(new PageAsyncTask(async (t) =>
		{
			using (var wc = new WebClient())
			{
				await wc.DownloadFileTaskAsync(imageUrl, this.Server.MapPath(product.ImagePath));
			}
		}));
	}
}