'use strict';

angular.module("bertha")
	.directive("bthSounds", function() {
	var controller = [
		"$scope", function($scope) {
		}
	];

	return {
		restrict: "E",
		scope: {
			sounds: "="
		},
		templateUrl: "Content/j/directives/templates/bthSounds.html",
		controller: controller
	};
});