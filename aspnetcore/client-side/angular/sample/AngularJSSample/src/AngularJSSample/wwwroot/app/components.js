// module
var personApp = angular.module('personApp', []);

// controller
var PersonController = function(){
	
	var vm = this;
	vm.firstName = "Aftab";
	vm.lastName = "Ansari";
}

// component
personApp.component('personComponent', {
    templateUrl:'/app/partials/personcomponent.html',
	controller:PersonController,
	controllerAs:'vm'
	
});
