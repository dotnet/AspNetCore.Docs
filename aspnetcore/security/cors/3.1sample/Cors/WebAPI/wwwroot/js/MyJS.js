function MyTestCors3(host, uri, methodName, includeHeaders=false) {
    const resultSpan = document.getElementById('result');
    const myHeaders = includeHeaders ? { 'Content-Type': 'x-custom-header' } : {};

    fetch(`${host}${uri}`,
        {
            method: methodName,
            headers: myHeaders,
        }).then(response => {
            if (response.ok) {
                response.text().then(text => {
                    resultSpan.innerText = text;
                });
            }
            else {
                resultSpan.innerText = response.status;
            }
        })
        .catch(() => resultSpan.innerText = 'See F12 Console for error');
}
