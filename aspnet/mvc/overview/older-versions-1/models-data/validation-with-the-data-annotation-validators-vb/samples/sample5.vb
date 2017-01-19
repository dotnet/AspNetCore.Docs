Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

 _
Partial Public Class Movie
End Class

Public Class MovieMetaData

    Private _title As Object
    Private _director As Object
    Private _dateReleased As Object

     _
    Public Property Title() As Object
        Get
            Return _title
        End Get
        Set(ByVal value As Object)
            _title = value
        End Set
    End Property

     _
    Public Property Director() As Object
        Get
            Return _director
        End Get
        Set(ByVal value As Object)
            _director = value
        End Set
    End Property

     _
    Public Property DateReleased() As Object
        Get
            Return _dateReleased
        End Get
        Set(ByVal value As Object)
            _dateReleased = value
        End Set
    End Property
End Class