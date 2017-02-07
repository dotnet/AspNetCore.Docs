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

End Class