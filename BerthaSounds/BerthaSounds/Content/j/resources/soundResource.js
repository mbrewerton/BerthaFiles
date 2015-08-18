'use strict';

angular.module('bertha')
    .factory('soundFactory', [
        '$resource', function ($resource) {
        	return $resource("api/Sounds", {}, {
        		getAllSounds: {
        			method: "GET",
        			url: "/api/Sounds/GetAllSounds",
        			isArray: true
        		},
                uploadSound: {
                    method: "POST",
                    url: "/api/Sounds/UploadSound",
                    params: { file: "@file"}
                }
            });
        }
    ]);