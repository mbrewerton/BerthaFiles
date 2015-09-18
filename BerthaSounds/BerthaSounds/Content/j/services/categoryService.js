'use strict';
angular.module("bertha")
	.factory("categoryService", [
		"categoryFactory",
		function(categoryFactory) {
			var service = {
				search: function(term, callback) {
					return categoryFactory.search({ term: term }).$promise.then(callback);
				},
				getCategories: function(callback) {
					return categoryFactory.getCategories().$promise.then(callback);
				},
				addCategory: function(name, description, callback) {
					return categoryFactory.addCategory({name: name, description: description}).$promise.then(callback);
				},
				deleteCategory: function(category, callback) {
					return categoryFactory.deleteCategory({ id: category.id }).$promise.then(callback);
				}
			};

			return service;
		}
	]);