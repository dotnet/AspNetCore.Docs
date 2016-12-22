public static bool IsUrlLocalToHost(this HttpRequestBase request, string url)
{
   return !url.IsEmpty() &&
          ((url[0] == '/' && (url.Length == 1 ||
           (url[1] != '/' && url[1] != '\\'))) ||   // "/" or "/foo" but not "//" or "/\"
           (url.Length > 1 &&
            url[0] == '~' && url[1] == '/'));   // "~/" or "~/foo"
}