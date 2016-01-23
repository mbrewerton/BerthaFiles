'use strict';

angular.module("bertha")
	.directive("bthToggleHeader", function() {
	var controller = [
		"$scope", "_", function ($scope, _) {
			if ($scope.tglOpen)
				$scope.tglShowSection = true;

			$scope.toggleShowSection = function() {
				$scope.tglShowSection = !$scope.tglShowSection;
			};
		}
	];

	return {
		restrict: "E",
		scope: {
			tglHeading: "@",
			tglShowSection: "=",
			tglOpen: "=?"
		},
        transclude: true,
		templateUrl: "Content/j/directives/templates/bthToggleHeader.html",
		controller: controller
	};
});