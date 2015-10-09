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
					console.log("Profile in service: ", profile);
					//return userProfileFactory.updateUserProfile({ id: profile.id, displayName: profile.displayName, firstName: profile.firstName, lastName: profile.lastName }).$promise.then(callback);
					return userProfileFactory.updateUserProfile(profile).$promise.then(callback);
				}
			};

			return service;
		}
	]);