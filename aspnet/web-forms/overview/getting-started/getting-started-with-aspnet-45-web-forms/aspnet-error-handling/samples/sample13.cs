public string HttpCall(string NvpRequest)
{
  string url = pEndPointURL;

  string strPost = NvpRequest + "&" + buildCredentialsNVPString();
  strPost = strPost + "&BUTTONSOURCE=" + HttpUtility.UrlEncode(BNCode);

  HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
  objRequest.Timeout = Timeout;
  objRequest.Method = "POST";
  objRequest.ContentLength = strPost.Length;

  try
  {
    using (StreamWriter myWriter = new StreamWriter(objRequest.GetRequestStream()))
    {
      myWriter.Write(strPost);
    }
  }
  catch (Exception e)
  {
    // Log the exception.
    WingtipToys.Logic.ExceptionUtility.LogException(e, "HttpCall in PayPalFunction.cs");
  }

  //Retrieve the Response returned from the NVP API call to PayPal.
  HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
  string result;
  using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
  {
    result = sr.ReadToEnd();
  }

  return result;
}