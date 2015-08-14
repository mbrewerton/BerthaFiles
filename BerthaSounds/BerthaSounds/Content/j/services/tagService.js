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
				}
			};

			return service;
		}
	]);