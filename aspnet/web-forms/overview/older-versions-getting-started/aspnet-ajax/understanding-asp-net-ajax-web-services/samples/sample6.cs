[WebMethod]
[ScriptMethod(UseHttpGet = true)]
public string HttpGetEcho(string input)
{
     return input;
}