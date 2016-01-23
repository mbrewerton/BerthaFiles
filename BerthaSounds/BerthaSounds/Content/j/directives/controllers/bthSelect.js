'use strict';

angular.module("bertha")
	.directive("bthSelect", function() {
	var controller = [
		"$scope", function ($scope) {
			
		}
	];

	return {
		restrict: "E",
		scope: {
		},
		templateUrl: "Content/j/directives/templates/bthSelect.html",
		controller: controller
	};
});