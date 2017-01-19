HttpClientHandler handler = new HttpClientHandler()
{
    UseDefaultCredentials = true
};

HttpClient client = new HttpClient(handler);