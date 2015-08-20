'use strict';

angular.module("bertha")
	.directive("bthSearch", function() {
	var controller = [
		"$scope", "_", function ($scope, _) {
			$scope.searchData = function() {
			};
		}
	];

	return {
		restrict: "E",
		scope: {
			schModel: "=",
			schData: "=",
			schField: "="
		},
		templateUrl: "Content/j/directives/templates/bthSearch.html",
		controller: controller
	};
});