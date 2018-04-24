function addItem() {
    var item = {
        'name': $('#add-name').val(),
        'isComplete': false
    };

    $.ajax(
        {
            type: "post",
            accepts: "application/json",
            url: uri,
            contentType: "application/json",
            data: JSON.stringify(item),
            success: function (result) {
                getData();
                $('#add-name').val('');
            }
        }
    );
};