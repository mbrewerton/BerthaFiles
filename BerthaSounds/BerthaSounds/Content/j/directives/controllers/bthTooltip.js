'use strict';

angular.module("bertha")
	.directive("tooltip", function() {
	var controller = [
		"$scope", function ($scope) {
			if (!$scope.message)
				console.log("Tooltip --> Message has not been set.");
		}
	];

	return {
		restrict: "E",
		scope: {
			message: "@"
		},
		templateUrl: "Content/j/directives/templates/bthTooltip.html",
		controller: controller
	};
});