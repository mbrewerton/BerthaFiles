'use strict';

angular.module("bertha")
	.directive("bthToggleButton", function() {
	var controller = [
		"$scope", function ($scope) {
			$scope.small = $scope.btnSmall ? $scope.btnSmall : false;

			$scope.toggleConfirmMode = function() {
				$scope.confirmMode = !$scope.confirmMode;
			}
		}
	];

	return {
		restrict: "E",
		scope: {
			btnConfirmAction: "&",
			btnSmall: "@?",
			btnMessage: "@?"
		},
		templateUrl: "Content/j/directives/templates/bthToggleButton.html",
		controller: controller
	};
});