self.detail = ko.observable();

self.getBookDetail = function (item) {
    ajaxHelper(booksUri + item.Id, 'GET').done(function (data) {
        self.detail(data);
    });
}