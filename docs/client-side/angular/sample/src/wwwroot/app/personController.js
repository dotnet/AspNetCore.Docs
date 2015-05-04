(function () {
    'use strict';

    var controllerId = 'personController';

    angular.module('PersonsApp').controller(controllerId, ['$scope', personFactory, personController]);

    function personController($scope, personFactory) {
        $scope.people = [];

        personFactory.getPeople().success(function (data) {
            $scope.people = data;
        }).error(function (error) {
            // log errors
        });
    }
})();