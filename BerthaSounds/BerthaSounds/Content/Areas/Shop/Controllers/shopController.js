'use strict';

angular.module('bertha')
    .controller('shopController', ['$scope', '$location', '_', 'soundFactory',
        function ($scope, $location, _, soundFactory) {
        	console.log(">> Shop Controller");

	        soundFactory.getAllSounds().$promise.then(function(sounds) {
	        	$scope.sounds = sounds;
	        });
        }]);