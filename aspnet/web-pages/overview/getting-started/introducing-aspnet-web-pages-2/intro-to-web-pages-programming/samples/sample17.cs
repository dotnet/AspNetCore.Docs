@{
   var message = "This is the first time you've requested the page.";

   if (IsPost) {
      message = "Now you've submitted the page.";
   }

   var showMessage = false;
   if (Request.QueryString["show"].AsBool() == true) {
     showMessage = true;
   }
}

<!DOCTYPE html>
<html lang="en">
  <head>
    <title>Testing Razor Syntax - Part 2</title>
    <meta charset="utf-8" />
    <style>
      body {font-family:Verdana; margin-left:50px; margin-top:50px;}
      div {border: 1px solid black; width:50%; margin:1.2em;padding:1em;}
    </style>
  </head>
  <body>
  <h1>Testing Razor Syntax - Part 2</h1>
  <form method="post">
    <div>
      <!--<p>@message</p>-->
      @if(showMessage){
        <p>@message</p>
      }
      <p><input type="submit" value="Submit" /></p>
      @if (IsPost) {
        <p>You submitted the page at @DateTime.Now</p>
      }
    </div>
  </form>
</body>
</html>