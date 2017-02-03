hasError: function () {
    var currentError = this.get("error");
    return !(currentError === '' || currentError === null);
}.property('error'),