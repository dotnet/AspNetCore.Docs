@{
    Layout = "~/Shared/_Layout3.cshtml";

    PageData["Title"] = "Passing Data";
    PageData["ShowList"] = true;

    if (IsPost) {
        if (Request.Form["list"] == "off") {
            PageData["ShowList"] = false;
        }
    }
}

@section header {
  <div id="header">
    Creating a Consistent Look
  </div>
}

<h1>@PageData["Title"]</h1>
<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit,
sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris
nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in
reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
pariatur. Excepteur sint occaecat cupidatat non proident, sunt in
culpa qui officia deserunt mollit anim id est laborum.</p>

@if (PageData["ShowList"] == true) {
    <form method="post" action="">
      <input type="hidden" name="list" value="off" />
      <input type="submit" value="Hide List" />
    </form>
}
else {
    <form method="post" action="">
      <input type="hidden" name="list" value="on" />
      <input type="submit" value="Show List" />
    </form>
}