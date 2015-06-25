(function () {
    'use strict';

    var serviceId = 'personFactory';

    angular.module('PersonsApp').factory(serviceId,
        ['$http', personFactory]);

    function personFactory($http) {

        function getPeople() {
            return $http.get('/api/people');
        }

        var service = {
            getPeople: getPeople
        };

        return service;
    }
})();
