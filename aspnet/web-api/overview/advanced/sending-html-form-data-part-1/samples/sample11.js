$('#form2').submit(function () {
    var jqxhr = $.post('api/updates/simple', { "": $('#status1').val() })
        .success(function () {
            var loc = jqxhr.getResponseHeader('Location');
            var a = $('<a/>', { href: loc, text: loc });
            $('#message').html(a);
        })
        .error(function () {
            $('#message').html("Error posting the update.");
        });
    return false;
});