@Code
   Dim result = ""
   If IsPost Then
      result = "This page was posted using the Submit button."
   Else
      result = "This was the first request for this page."
   End If
End Code
<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8" />
        <title>Write Code that Makes Decisions</title>
    </head>
<body>
    
    <form method="POST" action="" >
        <input type="Submit" name="Submit" value="Submit"/>
        <p>@result</p>
    </form>
    
</body>
</html>