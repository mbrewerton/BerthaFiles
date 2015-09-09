'use strict';
angular.module("bertha")
	.factory("soundService", [
		"soundFactory",
		function (soundFactory) {
			var service = {
				getSounds: function(callback) {
					return soundFactory.getAllSounds().$promise.then(callback);
				},
				uploadSound: function(sound, callback) {
					return soundFactory.uploadSound(sound).$promise.then(callback);
				}
			};

			return service;
		}
	]);