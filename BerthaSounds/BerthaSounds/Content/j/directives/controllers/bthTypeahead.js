'use strict';

angular.module("bertha")
	.directive("bthTypeahead", function() {
	var controller = [
		"$scope", function ($scope) {
			
		}
	];

	return {
		restrict: "E",
		scope: {
		},
		templateUrl: "Content/j/directives/templates/bthTypeahead.html",
		controller: controller
	};
});