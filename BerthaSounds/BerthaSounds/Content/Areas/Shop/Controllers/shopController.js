'use strict';

angular.module('bertha')
    .controller('shopController', ['$scope', '$location', '_', 'soundService',
        function ($scope, $location, _, soundService) {
        	console.log(">> Shop Controller");

	        $scope.searchData = {
				term: ""
	        };

	        soundService.search($scope.searchData, function(sounds) {
	        	$scope.sounds = sounds;
	        });
        }]);