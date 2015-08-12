'use strict';

angular.module("bertha")
	.directive("bthSounds", function() {
	var controller = [
		"$scope", function($scope) {
			console.log("directive hit");
		}
	];

	return {
		restrict: "E",
		scope: {},
		controller: controller,
		template: "Content/j/directives/templates/bthSounds.html"
	};
});