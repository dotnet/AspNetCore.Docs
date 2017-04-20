(function () {
    'use strict';

    var controllerId = 'personController';

    angular.module('PersonsApp').controller(controllerId,
        ['$scope', 'personFactory', personController]);

    function personController($scope, personFactory) {
        $scope.people = [];

        personFactory.getPeople().then(
            // callback function for successful http request
            function success(response) {
                $scope.people = response.data;
            },
            // callback function for error in http request
            function error(response) {
                // log errors
            }
        );
    }
})();