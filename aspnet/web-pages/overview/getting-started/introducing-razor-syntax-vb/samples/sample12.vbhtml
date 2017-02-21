@If IsPost Then
    ' Plain text followed by an unmatched HTML tag and server code.
    @:The time is: <br /> @DateTime.Now
    ' Server code and then plain text, matched tags, and more text.
    @DateTime.Now @:is the <em>current</em> time.
End If