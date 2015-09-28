'use strict';

angular.module('bertha')
    .factory('tagFactory', [
        '$resource', function ($resource) {
        	return $resource("api/Tags", {}, {
        		search: {
        			method: "GET",
        			url: "api/Tags/Search",
        			isArray: true
        		},
        		addTag: {
        			method: "POST",
        			url: "api/Tags/AddTag"
        		},
        		deleteTag: {
        			method: "DELETE",
        			url: "api/Tags/DeleteTag"
        		}
            });
        }
    ]);