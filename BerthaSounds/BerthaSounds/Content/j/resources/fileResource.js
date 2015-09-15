'use strict';

angular.module('bertha')
    .factory('fileFactory', [
        '$resource', function ($resource) {
        	return $resource("api/File", {}, {
        		upload: {
        			method: "POST",
        			url: "/api/File/UploadFile"
        		}
            });
        }
    ]);