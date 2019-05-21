

$.ajax("/home/secureinfo", {
    type: "GET",
    //headers: {
    //    "X-Requested-With": "XMLHttpRequest"
    //}
})
    .done(function (result) {
        $(".test-jquery").append(result)
    })
    .fail(function (xhr) {
        if (xhr.status == 401) {
            alert("you need to login first (handled by jquery)");
        }
        
    })


var xhr = new XMLHttpRequest();
xhr.open("GET", "/home/secureinfo", true);
xhr.setRequestHeader("X-Requested-With", "XMLHttpRequest");
xhr.onreadystatechange = function () {
    if (xhr.readyState == 4) {
        if (xhr.status == 401) {
            alert("you need to login first (handled by XMLHttpRequest)");
        }
        else if (xhr.status >= 200 && xhr.status < 300) {
            $(".test-jquery").append(xhr.responseText)
        }
        else {
            alert("request fail");
        }
    }
}
xhr.send();