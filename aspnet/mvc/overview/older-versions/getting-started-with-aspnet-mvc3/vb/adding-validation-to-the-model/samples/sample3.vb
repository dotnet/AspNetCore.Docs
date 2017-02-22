Dim db As New MovieDBContext()

Dim movie As New Movie()
movie.Title = "Gone with the Wind"
movie.Price = 0.0D

db.Movies.Add(movie)
db.SaveChanges() ' <= Will throw validation exception