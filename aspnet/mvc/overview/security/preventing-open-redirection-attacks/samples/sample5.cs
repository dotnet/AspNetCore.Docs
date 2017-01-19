private bool IsLocalUrl(string url)
{
   if (string.IsNullOrEmpty(url))
   {
      return false;
   }
   else
   {
      return ((url[0] == '/' && (url.Length == 1 ||
              (url[1] != '/' && url[1] != '\\'))) ||   // "/" or "/foo" but not "//" or "/\"
              (url.Length > 1 &&
               url[0] == '~' && url[1] == '/'));   // "~/" or "~/foo"
   }
}