var response = await fetch("/antiforgery/token", {
    method: "GET",
    headers: { "Authorization": authorizationToken }
});

if (response.ok) {
    // https://developer.mozilla.org/docs/web/api/document/cookie
    const xsrfToken = document.cookie
        .split("; ")
        .find(row => row.startsWith("XSRF-TOKEN="))
        .split("=")[1];

    response = await fetch("/JavaScript/FetchEndpoint", {
        method: "POST",
        headers: { "X-XSRF-TOKEN": xsrfToken, "Authorization": authorizationToken }
    });

    if (response.ok) {
        resultElement.innerText = await response.text();
    } else {
        resultElement.innerText = `Request Failed: ${response.status}`
    }
} else {    
    resultElement.innerText = `Request Failed: ${response.status}`
}