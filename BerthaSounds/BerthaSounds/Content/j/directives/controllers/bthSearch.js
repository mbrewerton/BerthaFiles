'use strict';

angular.module("bertha")
	.directive("bthSearch", function() {
	var controller = [
		"$scope", "_", function ($scope, _) {
		}
	];

	return {
		restrict: "E",
		scope: {
			sModel: "=",
			sSearch: "&",
			sDebounce: "@"
		},
		templateUrl: "Content/j/directives/templates/bthSearch.html",
		controller: controller
	};
});