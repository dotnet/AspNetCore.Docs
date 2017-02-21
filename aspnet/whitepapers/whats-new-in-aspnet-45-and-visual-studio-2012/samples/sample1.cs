private async Task
ScrapeHtmlPage(object caller, EventArgs e)
{
	WebClient wc = new WebClient();
	var result = await wc.DownloadStringTaskAsync("http://www.microsoft.com");
	// Do something with the result
}