'use strict';

angular.module('bertha')
    .controller('soundManagementController', ['$scope', '$rootScope', '$location', '$upload', '_', 'soundService', 'toastService', 'categoryService', 'tagService',
        function ($scope, $rootScope, $location, $upload, _, soundService, toastService, categoryService, tagService) {
            console.log('>> Sound Management Controller');

        	/* #region Init */

	        $scope.getCategories = function(term) {
	        	return categoryService.search(term, function (categories) {
			        return categories;
		        });
	        };

	        $scope.searchData = {
		        term: ""
	        };

	        $scope.search = function () {
	        	soundService.search($scope.searchData, function (sounds) {
	        		$scope.sounds = sounds;
	        	});
	        };

	        $scope.getTags = function(term) {
		        return tagService.search(term, function(tags) {
			        return tags;
		        });
	        };

	        $scope.files = [];
	        $scope.sortField = "Id";
	        $scope.sortReverse = false;
        	/* #endregion */

	        $scope.setSortField = function(sortField) {
	        	$scope.sortField = sortField;
		        $scope.sortReverse = !$scope.sortReverse;
	        };

            $scope.uploadSound = function() {
                soundService.uploadSound($scope.soundUpload.file);
            };

            $scope.addCategoryToSound = function (sound, category) {
            	var exists = _.find(sound.categories, category);
            	if (exists) {
            		toastService.throwDuplicateItemToast("add", category.name + " to " + sound.name);
		            sound.newCategory = "";
		            return;
	            }

            	soundService.addCategoryToSound(sound.id, category.id, function () {
	            	sound.categories.push(category);
		            $scope.toggleAddNewCategory(sound);
	            });
	            sound.newCategory = "";
            };

            $scope.deleteCategoryFromSound = function (sound, category) {
            	soundService.removeCategoryFromSound(sound.id, category.id, function () {
		            sound.categories = _.without(sound.categories, category);
		            toastService.throwDeleteSuccessToast(category.name);
	            });
            };

	        $scope.toggleAddNewCategory = function(sound) {
		        sound.addNewCategory = !sound.addNewCategory;
	        };

	        $scope.addTagToSound = function (sound, tag) {
	        	var exists = _.find(sound.tags, tag);
	        	if (exists) {
	        		toastService.throwDuplicateItemToast("add", tag.name + " to " + sound.name);
	        		sound.newTag = "";
	        		return;
	        	}

            	soundService.addTagToSound(sound.id, tag.id, function() {
            		sound.tags.push(tag);
		            $scope.toggleAddNewTag(sound);
	            });
	            sound.newTag = "";
            };

            $scope.deleteTagFromSound = function (sound, tag) {
	            soundService.removeTagFromSound(sound.id, tag.id);
            };

	        $scope.toggleAddNewTag = function(sound) {
		        sound.addNewTag = !sound.addNewTag;
	        };

            $scope.upload = function (files) {
                console.log("upload");
                if (files && files.length) {
                    for (var i = 0; i < files.length; i++) {
                        var file = files[i];
                        $upload.upload({
                            url: 'api/File/UploadFile',
                            file: file
                        }).progress(function(evt) {
                            var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                            console.log('progress: ' + progressPercentage + '% ' + evt.config.file.name);
                        }).success(function(data, status, headers, config) {
                            console.log('file ' + config.file.name + 'uploaded. Response: ' + data);
                        }).error(function(data, status, headers, config) {
                            console.log('error status: ' + status);
                        });
                    }
                }
            };

            $scope.init = function () {
	            $scope.search();
		        $scope.$watch("files", function () {
					if ($scope.files.length > 0)
			        $scope.upload($scope.files);
		        });
	        }();
        }]);