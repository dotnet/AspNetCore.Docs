var books = db.Books.ToList();  // Does not load authors
var author = books[0].Author;   // Loads the author for books[0]