// https://developer.mozilla.org/en-US/docs/web/api/document/cookie
const xsrfToken = document.cookie
    .split("; ")
    .find(row => row.startsWith("XSRF-TOKEN="))
    .split("=")[1];

const response = await fetch("/JavaScript/FetchEndpoint", {
    method: "POST",
    headers: { "X-XSRF-TOKEN": xsrfToken }
});

if (response.ok) {
    resultElement.innerText = await response.text();
} else {
    resultElement.innerText = `Request Failed: ${response.status}`
}
