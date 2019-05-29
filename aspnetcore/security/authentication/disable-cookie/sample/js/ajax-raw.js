function callApiWithHeader() {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/your-api-url", true);
    xhr.setRequestHeader("X-Requested-With", "XMLHttpRequest");
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {
            if (xhr.status == 401) {
                // Handle authentication here.
            }
            else if (xhr.status >= 200 && xhr.status < 300) {
                // Business logic here.
            }
            else {
                console.error("request fail");
            }
        }
    };
}