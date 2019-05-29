$.ajax("your-api-url", {
    type: "GET",
    headers: {
        "X-Requested-With": "XMLHttpRequest",
    }
})
    .done(function (result) {
        // Business logic here.
    })
    .fail(function (xhr) {
        if (xhr.status == 401) {
            // Handle authentication here.
        }
    })