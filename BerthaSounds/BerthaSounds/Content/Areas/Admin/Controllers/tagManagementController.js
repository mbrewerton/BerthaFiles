'use strict';

angular.module('bertha')
    .controller('tagManagementController', ['$scope', '$location', '_', 'tagService', "toastService",
        function ($scope, $location, _, tagService, toastService) {
        	console.log('>> Tag Controller');

            $scope.tags = [];
            $scope.newTag = {
            	name: "",
            	description: ""
            };

            $scope.getTags = function () {
            	tagService.getTags(function (tags) {
            		$scope.tags = tags;
            	});
            };

            $scope.addTag = function (newTag) {
            	tagService.addTag(newTag.name, function (tag) {
            		toastService.success(tag.name, "added", null);
            		$scope.tags.push(tag);
            	});
            }

            $scope.init = function () {
            	$scope.getTags();
            }();
        }]);