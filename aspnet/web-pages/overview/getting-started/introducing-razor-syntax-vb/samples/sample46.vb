@Code
    Dim weekday = "Wednesday"
    Dim greeting = ""
    
    Select Case weekday
        Case "Monday"
            greeting = "Ok, it's a marvelous Monday."
        Case "Tuesday"
            greeting = "It's a tremendous Tuesday."
        Case "Wednesday"
            greeting = "Wild Wednesday is here!"
        Case Else
            greeting = "It's some other day, oh well."
    End Select
End Code
<p>Since it is @weekday, the message for today is: @greeting</p>