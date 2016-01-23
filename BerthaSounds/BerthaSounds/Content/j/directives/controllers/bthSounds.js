'use strict';

angular.module("bertha")
	.directive("bthSounds", function() {
		var controller = [
			"$scope",
			function($scope) {
				$scope.init = function () {
					$scope.loading = true;
					$scope.$watch("sounds", function(sounds) {
						if (sounds != undefined)
							$scope.loading = false;
					});
				}();
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