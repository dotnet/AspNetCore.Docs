using System;
Imports System
Imports System.Collections.Generic
Imports System.Data.Entity

Namespace MvcMovie.Models
    Public Class MovieInitializer
        Inherits DropCreateDatabaseIfModelChanges(Of MovieDBContext)
        Protected Overrides Sub Seed(ByVal context As MovieDBContext)
            Dim movies = New List(Of Movie) From {
             New Movie With {.Title = "When Harry Met Sally", .ReleaseDate = Date.Parse("1989-1-11"), .Genre = "Romantic Comedy", .Rating = "R", .Price = 7.99D},
             New Movie With {.Title = "Ghostbusters ", .ReleaseDate = Date.Parse("1984-3-13"), .Genre = "Comedy", .Rating = "R", .Price = 8.99D},
             New Movie With {.Title = "Ghostbusters 2", .ReleaseDate = Date.Parse("1986-2-23"), .Genre = "Comedy", .Rating = "R", .Price = 9.99D},
             New Movie With {.Title = "Rio Bravo", .ReleaseDate = Date.Parse("1959-4-15"), .Genre = "Western", .Rating = "R", .Price = 3.99D}}

            movies.ForEach(Function(d) context.Movies.Add(d))
        End Sub
    End Class
End Namespace