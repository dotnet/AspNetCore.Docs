$(function () {
    setInterval(function() {
        $.ajax({
            url: "Ping.aspx",
            cache: false
        });
    }, 1800000);
});