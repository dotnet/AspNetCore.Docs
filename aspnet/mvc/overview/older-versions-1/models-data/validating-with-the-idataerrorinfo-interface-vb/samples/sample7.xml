Imports System.ComponentModel

Partial Public Class Movie
    Implements IDataErrorInfo

    Private _errors As New Dictionary(Of String, String)()

    Private Sub OnTitleChanging(ByVal value As String)
        If value.Trim().Length = 0 Then
            _errors.Add("Title", "Title is required.")
        End If
    End Sub

    Private Sub OnDirectorChanging(ByVal value As String)
        If value.Trim().Length = 0 Then
            _errors.Add("Director", "Director is required.")
        End If
    End Sub

#Region "IDataErrorInfo Members"

    Public ReadOnly Property [Error]() As String Implements IDataErrorInfo.Error
        Get
            Return String.Empty
        End Get
    End Property

    Default Public ReadOnly Property Item(ByVal columnName As String) As String Implements IDataErrorInfo.Item
        Get
            If _errors.ContainsKey(columnName) Then
                Return _errors(columnName)
            End If
            Return String.Empty
        End Get
    End Property

#End Region

End Class