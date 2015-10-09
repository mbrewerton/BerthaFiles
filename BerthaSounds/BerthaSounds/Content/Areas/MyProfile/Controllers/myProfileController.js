'use strict';

angular.module('bertha')
    .controller('myProfileController', ['$scope', '$location', '_', 'userProfileService', 'toastService',
        function ($scope, $location, _, userProfileService, toastService) {
        	var _private = this;
	        $scope.profile = {};
	        $scope.newProfile = {};

        	_private.getCurrentUserProfile = function() { 
        		userProfileService.getCurrentUserProfile(function (data) {
        			$scope.profile = data;
			        _private.setupNewProfile();
					console.log("Profile: ", data);
        		});
        	}

        	_private.setupNewProfile = function () {
        		// Must set properties individually, otherwise profile and newProfile get bound to the same object.
        		$scope.newProfile.id = $scope.profile.id;
	        	$scope.newProfile.displayName = $scope.profile.displayName;
	        	$scope.newProfile.firstName = $scope.profile.firstName;
	        	$scope.newProfile.lastName = $scope.profile.lastName;
	        };

        	$scope.toggleEditProfile = function() {
        		$scope.editingProfile = !$scope.editingProfile;
        	};

        	$scope.cancelEditing = function () {
		        _private.setupNewProfile();
        		$scope.toggleEditProfile();
        	};

        	$scope.saveProfile = function() {
		        var error = false;
        		if ($scope.newProfile.displayName.length === 0) {
        			toastService.error("Please enter a Display Name");
			        error = true;
		        }
        		if ($scope.newProfile.firstName.length === 0) {
			        toastService.error("Please enter a First Name");
			        error = true;
		        }
        		if ($scope.newProfile.lastName.length === 0) {
			        toastService.error("Please enter a Last Name");
			        error = true;
		        }

		        if (!error) {
			        userProfileService.updateUserProfile($scope.newProfile, function(data) {
			        	console.log("returned: ", data);
				        toastService.success("Profile", "saved");
				        $scope.toggleEditProfile();
				        _private.getCurrentUserProfile();
			        });
		        }
	        };

	        $scope.init = function() {
		        _private.getCurrentUserProfile();
	        }();
        }]);