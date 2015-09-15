'use strict';
angular.module("bertha")
	.factory("fileService", [
		"fileFactory",
		function (fileFactory) {
			var service = {
				uploadSound: function(file, callback) {
					return fileFactory.uploadFile(file).$promise.then(callback);
				}
			};

			return service;
		}
	]);