[WebMethod]
[ScriptMethod(ResponseFormat = ResponseFormat.Xml)]
public XmlElement GetRssFeed(string url)
{
     XmlDocument doc = new XmlDocument();
     doc.Load(url);
     return doc.DocumentElement;
}