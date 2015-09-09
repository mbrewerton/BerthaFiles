'use strict';

angular.module("bertha")
	.directive("bthDelete", function() {
	var controller = [
		"$scope", function ($scope) {
			$scope.buttonTitle = $scope.delTitle ? $scope.delTitle : "Delete";
			$scope.small = $scope.delSmall ? $scope.delSmall : false;

			$scope.toggleConfirmMode = function() {
				$scope.confirmMode = !$scope.confirmMode;
			}
		}
	];

	return {
		restrict: "E",
		scope: {
			delConfirmAction: "&",
			delSmall: "@?",
			delMessage: "@?",
			delTitle: "@?"
		},
		templateUrl: "Content/j/directives/templates/bthDelete.html",
		controller: controller
	};
});