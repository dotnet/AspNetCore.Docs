@using Microsoft.Web.Helpers;
@{
  var showRecaptcha = true;
  if (IsPost) {
    if (ReCaptcha.Validate()) {
        @:Your response passed!
        showRecaptcha = false;
    }
    else{
      @:Your response didn't pass!
    }
  }
}
<!DOCTYPE html>
<html>
    <head>
        <title>Testing Global Recaptcha Keys</title>
    </head>
    <body>
    <form action="" method="post">
    @if(showRecaptcha == true){
        if(ReCaptcha.PrivateKey != ""){
            <p>@ReCaptcha.GetHtml()</p>
            <input type="submit" value="Submit" />
        }
        else {
            <p>You can get your public and private keys at
            the ReCaptcha.Net website (http://recaptcha.net).
            Then add the keys to the _AppStart.cshtml file.</p>
        }
    }
    </form>
    </body>
</html>