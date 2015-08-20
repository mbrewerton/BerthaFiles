'use strict';
angular.module("bertha")
	.factory("tagService", [
		"tagFactory",
		function(tagFactory) {
			var service = {
				getTags: function(callback) {
					return tagFactory.getTags().$promise.then(callback);
				},
				addTag: function(name, callback) {
					return tagFactory.addTag({name: name}).$promise.then(callback);
				},
				deleteTag: function(tag, callback) {
					return tagFactory.deleteTag({ id: tag.id }).$promise.then(callback);
				}
			};

			return service;
		}
	]);