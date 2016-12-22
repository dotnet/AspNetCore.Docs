Public Sub NewContosoChatMessage(message As String)
    Dim userName As String = Clients.CallerState.userName
    Dim computerName As String = Clients.CallerState.computerName
    Clients.Others.addContosoChatMessageToPage(message, userName, computerName)
End Sub