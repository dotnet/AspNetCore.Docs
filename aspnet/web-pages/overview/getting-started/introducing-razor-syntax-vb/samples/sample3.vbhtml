<!-- Single statement block. -->
@Code
    Dim theMonth = DateTime.Now.Month
End Code

<!-- Multi-statement block. -->
@Code
    Dim outsideTemp = 79
    Dim weatherMessage = "Hello, it is " & outsideTemp & " degrees."
End Code 

<!-- An inline expression, so no line break needed. -->
<p>Today's weather: @weatherMessage</p>