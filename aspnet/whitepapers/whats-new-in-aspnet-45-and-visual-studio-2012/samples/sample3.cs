public class MyAsyncHandler : HttpTaskAsyncHandler
{
	// ...
	 
	// ASP.NET automatically takes care of integrating the Task based override
	// with the ASP.NET pipeline.
	public override async Task ProcessRequestAsync(HttpContext context)
	{
		WebClient wc = new WebClient();
		var result = await 
		   wc.DownloadStringTaskAsync("http://www.microsoft.com");
		// Do something with the result
	}
}