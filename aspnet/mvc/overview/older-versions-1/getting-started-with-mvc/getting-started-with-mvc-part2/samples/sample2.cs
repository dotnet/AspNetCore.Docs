public string Welcome(string name, int numTimes = 1)
{
   string message = "Hello " + name + ", NumTimes is: " + numTimes;
   return "" + Server.HtmlEncode(message) + "";
}