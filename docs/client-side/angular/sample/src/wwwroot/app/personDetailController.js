personApp.controller('personDetailController', ['$scope', '$routeParams',
  function($scope, $routeParams) {
    $scope.personId = $routeParams.personId;
  }]);
