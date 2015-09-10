'use strict';

angular.module("bertha")
	.directive("bthSort", function() {
	var controller = [
		"$scope", function ($scope) {
			if (!$scope.sortReverse)
				$scope.sortReverse = false;
		}
	];

	return {
		restrict: "E",
		scope: {
			sortField: "@",
			sortReverse: "=?"
		},
		templateUrl: "Content/j/directives/templates/bthSort.html",
		controller: controller
	};
});