personApp.factory('personFactory', function ($http) {
    function getName() {
        return "Mary Jane";
    }

    var service = {
        getName: getName
    };

    return service;
});