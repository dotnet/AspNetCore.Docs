<!-- Single statement blocks  -->
@Code  Dim total = 7  End Code
@Code  Dim myMessage = "Hello World" End Code

<!-- Inline expressions -->
<p>The value of your account is: @total </p>
<p>The value of myMessage is: @myMessage</p>        
    
<!-- Multi-statement block -->    
@Code 
    Dim greeting = "Welcome to our site!"
    Dim weekDay = DateTime.Now.DayOfWeek
    Dim greetingMessage = greeting & " Today is: " & weekDay.ToString()
End Code 
<p>The greeting is: @greetingMessage</p>