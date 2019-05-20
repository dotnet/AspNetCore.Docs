// using jquery

$.ajax("your-api-url", {
    type: "GET",
    headers: {
        "X-Requested-With": "XMLHttpRequest",
    }
})
    .done(function (result) {
        // do your business logic here
    })
    .fail(function (xhr) {
        if (xhr.status == 401) {
            //handle authentication here
        }
    })