'use strict';

angular.module("bertha")
	.directive("bthLoading", function() {
		var controller = [
			   '$scope', '$element', '$attrs',
			   function ($scope, $element, $attrs) {

			   	$scope.init = function () {
			   		if ($element[0].nodeName === "SELECT") {
			   			var e = $element[0];
			   			var o = document.createElement('option');
			   			o.appendChild(document.createTextNode('Please wait...'));
			   			o.id = 'LoadingOption';
			   			o.value = '';
			   			e.appendChild(o);
			   		}
			   		$scope.loadMessage = $scope.loadMessage ? $scope.loadMessage : "Loading, please wait...";

			   		$scope.$watch("loading", function (value) {
			   			if ($element[0].nodeName === "SELECT" && !value) {
			   				$("#LoadingOption").remove();
			   			};
			   		});
			   	}();
			   }
		];

		return {
			restrict: "EA",
			scope: {
				loading: "=",
				loadMessage: "@?",
				small: "=?"
			},
			transclude: true,
			templateUrl: "Content/j/directives/templates/bthLoading.html",
			controller: controller
		};
	});