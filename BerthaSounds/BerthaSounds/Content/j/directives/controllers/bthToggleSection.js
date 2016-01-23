'use strict';

angular.module("bertha")
	.directive("bthToggleSection", function() {
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
		restrict: "AE",
		scope: {
			tglHeading: "@",
			tglOpen: "=?"
		},
        transclude: true,
		templateUrl: "Content/j/directives/templates/bthToggleSection.html",
		controller: controller
	};
});