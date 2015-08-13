'use strict';

angular.module('bertha')
    .factory('categoryFactory', [
        '$resource', function ($resource) {
        	return $resource("api/Category", {}, {
				getCategories: {
					method: "GET",
					url: "api/Category/GetCategories",
					isArray: true
				},
        		addCategory: {
        			method: "POST",
					url: "api/Category/AddCategory"
				}
            });
        }
    ]);