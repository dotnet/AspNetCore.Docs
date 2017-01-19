protected void StartAsync_Click(object sender, EventArgs e)
{
    Page.RegisterAsyncTask(new PageAsyncTask(async() =>
    {
        string stringToRead = "Long text value";

        using (StringReader reader = new StringReader(stringToRead))
        {
            string readText = await reader.ReadToEndAsync();
            Result.Text = readText;
        }
    }));
}