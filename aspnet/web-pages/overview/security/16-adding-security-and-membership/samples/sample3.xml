@{
    if (!WebSecurity.IsAuthenticated) {
        Response.Redirect("~/Account/Login?returnUrl="
            + Request.Url.LocalPath);
    }
    Layout = "~/_SiteLayout.cshtml";
    Page.Title = "Members Information";
}
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8" />
    <title>Members Information</title>
  </head>
  <body>
    <p>You can only see this information if you've logged into the site.</p>
  </body>
</html>