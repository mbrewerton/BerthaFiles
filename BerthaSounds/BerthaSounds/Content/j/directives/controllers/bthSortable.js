'use strict';

angular.module("bertha")
	.directive("bthSortable", function() {
	var controller = [
		"$scope", function ($scope) {
		}
	];

	return {
		restrict: "A",
		scope: {
			text: "@"
		},
		templateUrl: "Content/j/directives/templates/bthSortable.html",
		controller: controller
	};
});