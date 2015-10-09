'use strict';

angular.module('bertha')
    .factory('userProfileFactory', [
        '$resource', function ($resource) {
        	return $resource("api/UserProfile", {}, {
        		getCurrentUserProfile: {
        			method: "GET",
        			url: "/api/UserProfile/GetCurrentUserProfile"
        		},
				updateUserProfile: {
					method: "PUT",
					url: "/api/UserProfile/UpdateUserProfile"
				}
            });
        }
    ]);