Public Class MovieRepository Implements IMovieRepository
         Private _dataContext As MovieDataContext

         Public Sub New()
              _dataContext = New MovieDataContext()
         End Sub

         Public Function ListAll() As IList(Of Movie) Implements IMovieRepository.ListAll
              Dim movies = From m In _dataContext.Movies _
                   Select m
              Return movies.ToList()
         End Function
End Class