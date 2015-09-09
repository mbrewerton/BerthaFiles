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
				},
				addCategoryToSound: function(soundId, categoryId, callback) {
					return soundFactory.addCategoryToSound({ soundId: soundId, categoryId: categoryId }).$promise.then(callback);
				},
				removeCategoryFromSound: function(soundId, categoryId, callback) {
					return soundFactory.removeCategoryFromSound({ soundId: soundId, categoryId: categoryId }).$promise.then(callback);
				}
			};

			return service;
		}
	]);