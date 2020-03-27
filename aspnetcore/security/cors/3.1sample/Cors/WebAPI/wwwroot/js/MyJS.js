function MyTestCors(host, uri, methodName) {
    const resultSpan = document.getElementById('result');

    fetch(host + uri,
        {
            method: methodName,

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
        .catch(error => resultSpan.innerText = 'See F12 Console for error');
}