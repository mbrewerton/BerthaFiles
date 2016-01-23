'use strict';

angular.module("bertha")
	.directive("tooltip", function() {
	var controller = [
		"$scope", function ($scope) {
		}
	];

	return {
		restrict: "E",
		scope: {
			message: "@?"
		},
        transclude: true,
		templateUrl: "Content/j/directives/templates/bthTooltip.html",
		controller: controller
	};
});