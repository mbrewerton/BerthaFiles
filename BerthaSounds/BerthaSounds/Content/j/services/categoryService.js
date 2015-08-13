'use strict';
angular.module("bertha")
	.factory("categoryService", [
		"categoryFactory",
		function(categoryFactory) {
			var service = {
				getCategories: function(callback) {
					return categoryFactory.getCategories().$promise.then(callback);
				},
				addCategory: function(name, description, callback) {
					return categoryFactory.addCategory({name: name, description: description}).$promise.then(callback);
				}
			};

			return service;
		}
	]);