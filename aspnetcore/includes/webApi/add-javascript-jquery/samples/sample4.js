$(document).ready(function () {
    getData();
});

function getData() {
    $.ajax({
        type: 'GET',
        url: uri,
        success: function (data) {
            $('#todos').empty();
            getCount(data.length);
            $.each(data, function (key, item) {
                var checked = '';
                if (item.isComplete) {
                    checked = 'checked'
                }

                $('<tr><td><input disabled=true type="checkbox" ' + checked + '></td><td>' + item.name + '</td>' +
                    '<td><button onclick="editItem(' + item.id + ')">Edit</button></td><td><button onclick="deleteItem(' + item.id + ')">' +
                    'Delete</button ></td></tr>').appendTo($('#todos'));
            });

            todos = data;
        }
    });
};