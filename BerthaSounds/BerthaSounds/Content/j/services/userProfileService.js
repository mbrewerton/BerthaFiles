'use strict';
angular.module("bertha")
	.factory("userProfileService", [
		"userProfileFactory",
		function (userProfileFactory) {
			var service = {
				getCurrentUserProfile: function(callback) {
					return userProfileFactory.getCurrentUserProfile().$promise.then(callback);
				},
				updateUserProfile: function (profile, callback) {
					return userProfileFactory.updateUserProfile(profile).$promise.then(callback);
				}
			};

			return service;
		}
	]);