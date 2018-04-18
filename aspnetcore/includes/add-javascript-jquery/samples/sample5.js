function find() {
    var id = $('#todoId').val();
    $.getJSON(apiUrl + '/' + id)
        .done(function (data) {
            $('#todo').text(formatItem(data));
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#todo').text('Error: ' + err);
        });
}