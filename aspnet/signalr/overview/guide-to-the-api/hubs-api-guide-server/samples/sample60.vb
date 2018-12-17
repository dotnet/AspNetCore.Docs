Public Async Function NewContosoChatMessage(message As String) As Task
    Dim userName As String = Clients.CallerState.userName
    Dim computerName As String = Clients.CallerState.computerName
    Await Clients.Others.addContosoChatMessageToPage(message, userName, computerName)
End Sub