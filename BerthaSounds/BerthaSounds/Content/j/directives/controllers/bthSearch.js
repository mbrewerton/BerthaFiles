'use strict';

angular.module("bertha")
	.directive("bthSearch", function() {
	var controller = [
		"$scope", "_", function ($scope, _) {
			$scope.search = function () {

			};
		}
	];

	return {
		restrict: "E",
		scope: {
			schModel: "="
		},
		templateUrl: "Content/j/directives/templates/bthSearch.html",
		controller: controller
	};
});