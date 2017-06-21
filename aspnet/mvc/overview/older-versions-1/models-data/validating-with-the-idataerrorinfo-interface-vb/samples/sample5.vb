Public Interface IDataErrorInfo
  Default ReadOnly Property Item(ByVal columnName As String) As String
  ReadOnly Property [Error]() As String
End Interface