self.authors = ko.observableArray();
self.newBook = {
    Author: ko.observable(),
    Genre: ko.observable(),
    Price: ko.observable(),
    Title: ko.observable(),
    Year: ko.observable()
}

var authorsUri = '/api/authors/';

function getAuthors() {
    ajaxHelper(authorsUri, 'GET').done(function (data) {
        self.authors(data);
    });
}

self.addBook = function (formElement) {
    var book = {
        AuthorId: self.newBook.Author().Id,
        Genre: self.newBook.Genre(),
        Price: self.newBook.Price(),
        Title: self.newBook.Title(),
        Year: self.newBook.Year()
    };

    ajaxHelper(booksUri, 'POST', book).done(function (item) {
        self.books.push(item);
    });
}

getAuthors();