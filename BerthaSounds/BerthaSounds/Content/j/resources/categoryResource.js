'use strict';

angular.module('bertha')
    .factory('categoryFactory', [
        '$resource', function ($resource) {
        	return $resource("api/Categories", {}, {
				getCategories: {
					method: "GET",
					url: "api/Categories/GetCategories",
					isArray: true
				},
        		addCategory: {
        			method: "POST",
        			url: "api/Categories/AddCategory"
        		},
				deleteCategory: {
					method: "DELETE",
					url: "api/Categories/DeleteCategory"
				}
            });
        }
    ]);