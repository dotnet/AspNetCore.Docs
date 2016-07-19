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
    templateUrl:'/Home/PersonComponent',
	controller:PersonController,
	controllerAs:'vm'
	
});
