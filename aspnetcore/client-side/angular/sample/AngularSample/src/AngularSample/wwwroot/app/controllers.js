// module
var personApp = angular.module('personApp', []);

// controller
personApp.controller('personController', function ($scope) {
    $scope.firstName = "Mary";
    $scope.lastName = "Jane"
});
