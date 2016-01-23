'use strict';

angular.module("bertha")
	.directive("lozenge", function() {
	var controller = [
		"$scope", function ($scope) {
		    $scope.callFunc = function ($item) {
		        $scope.func($item);
		    }
		}
	];

	return {
		restrict: "E",
		scope: {
		    readonly: "=?",
            func: "&?"
		},
        transclude: true,
		templateUrl: "Content/j/directives/templates/bthLozenge.html",
		controller: controller
	};
});