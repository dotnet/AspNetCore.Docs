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
      var startThread = Thread.CurrentThread.ManagedThreadId;

      using (var wc = new WebClient())
      {
        await wc.DownloadFileTaskAsync(imageUrl, this.Server.MapPath(product.ImagePath));
      }

      var endThread = Thread.CurrentThread.ManagedThreadId;

      this.threadsMessageLabel.Text = string.Format("Started on thread: {0}<br /> Finished on thread: {1}", startThread, endThread);
    }));
  }
}