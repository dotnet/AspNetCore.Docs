personApp.controller('eventHandlerController', function ($scope) {
    $scope.firstName = 'Mary';
    $scope.lastName = 'Jane';

    $scope.sayName = function () {
        alert('Welcome, ' + $scope.firstName + ' ' + $scope.lastName);
    }
});