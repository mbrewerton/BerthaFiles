'use strict';

angular.module('bertha')
    .factory('tagFactory', [
        '$resource', function ($resource) {
        	return $resource("api/Tags", {}, {
        		getTags: {
        			method: "GET",
        			url: "api/Tags/GetTags",
        			isArray: true
        		},
        		addTag: {
        			method: "POST",
        			url: "api/Tags/AddTag"
        		}
            });
        }
    ]);