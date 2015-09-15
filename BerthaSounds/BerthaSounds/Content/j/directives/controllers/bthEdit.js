'use strict';

angular.module("bertha")
	.directive("bthEdit", function() {
	var controller = [
		"$scope", function ($scope) {
			$scope.buttonTitle = $scope.editTitle ? $scope.editTitle : "Edit";
			$scope.small = $scope.editSmall ? $scope.editSmall : false;

			$scope.toggleConfirmMode = function() {
				$scope.confirmMode = !$scope.confirmMode;
			}
		}
	];

	return {
		restrict: "E",
		scope: {
			editItem: "=?",
			editConfirmAction: "&?",
			editSmall: "@?",
			editMessage: "@?",
			editTitle: "@?",
			editExclude: "@?"
		},
		templateUrl: "Content/j/directives/templates/bthEdit.html",
		controller: controller
	};
});