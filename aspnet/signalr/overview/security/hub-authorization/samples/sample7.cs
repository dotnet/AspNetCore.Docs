class Program
{
    static void Main(string[] args)
    {
        var connection = new HubConnection("http://www.contoso.com/");
        Cookie returnedCookie;

        Console.Write("Enter user name: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        var authResult = AuthenticateUser(username, password, out returnedCookie);

        if (authResult)
        {
            connection.CookieContainer = new CookieContainer();
            connection.CookieContainer.Add(returnedCookie);
            Console.WriteLine("Welcome " + username);
        }
        else
        {
            Console.WriteLine("Login failed");
        }    
    }

    private static bool AuthenticateUser(string user, string password, out Cookie authCookie)
    {
        var request = WebRequest.Create("https://www.contoso.com/RemoteLogin") as HttpWebRequest;
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.CookieContainer = new CookieContainer();

        var authCredentials = "UserName=" + user + "&Password=" + password;
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(authCredentials);
        request.ContentLength = bytes.Length;
        using (var requestStream = request.GetRequestStream())
        {
            requestStream.Write(bytes, 0, bytes.Length);
        }

        using (var response = request.GetResponse() as HttpWebResponse)
        {
            authCookie = response.Cookies[FormsAuthentication.FormsCookieName];
        }

        if (authCookie != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}