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

	        $scope.addTag = function(newTag) {
		        if (newTag.name.length === 0) {
			        toastService.error("Please enter a tag name");
			        return;
		        }

		        if (_.find($scope.tags, function(tag) {
			        return tag.name.toLowerCase() === newTag.name.toLowerCase();
		        })) {
			        toastService.throwDuplicateItemToast("add tag with name", newTag.name);
			        return;
		        }

		        tagService.addTag(newTag.name, function(tag) {
			        toastService.success(tag.name, "added", null);
			        $scope.tags.push(tag);
		        });
	        };

	        $scope.deleteTag = function (tag) {
	        	tagService.deleteTag(tag, function () {
	        		toastService.throwDeleteSuccessToast(tag.name);
			        $scope.tags = _.without($scope.tags, tag);
		        });
	        };

            $scope.init = function () {
            	$scope.getTags();
            }();
        }]);