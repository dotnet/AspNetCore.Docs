$.ajax({
    url: uri + '/' + id,
    type: 'DELETE',
    success: function (result) {
        getData();
    }
});