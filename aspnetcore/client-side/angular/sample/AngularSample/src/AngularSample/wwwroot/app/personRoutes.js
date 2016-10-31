personApp.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/persons', {
                templateUrl: '/app/partials/personlist.html',
                controller: 'personListController'
            }).
            when('/persons/:personId', {
                templateUrl: '/app/partials/persondetail.html',
                controller: 'personDetailController'
            }).
            otherwise({
                redirectTo: '/persons'
            })
    }
]);