var loginData = {
    grant_type: 'password',
    username: self.loginEmail(),
    password: self.loginPassword()
};

$.ajax({
    type: 'POST',
    url: '/Token',
    data: loginData
}).done(function (data) {
    self.user(data.userName);
    // Cache the access token in session storage.
    sessionStorage.setItem(tokenKey, data.access_token);
}).fail(showError);