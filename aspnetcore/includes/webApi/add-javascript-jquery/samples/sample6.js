$.ajax({
    url: uri + '/' + $('#edit-id').val(),
    type: 'PUT',
    accepts: "application/json",
    contentType: "application/json",
    data: JSON.stringify(item),
    success: function (result) {
        getData();
    }
});