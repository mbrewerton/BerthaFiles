'use strict';

angular.module('bertha')
    .controller('soundManagementController', ['$scope', '$rootScope', '$location', '$upload', '_', 'soundService', 'toastService', 'categoryService',
        function ($scope, $rootScope, $location, $upload, _, soundService, toastService, categoryService) {
            console.log('>> Sound Management Controller');

        	/* #region Init */
			
            soundService.getSounds(
				function (data) {
	                console.log(data);
                    $scope.soundFiles = data;
                    $scope.isLoadingSounds = false;
                });

            categoryService.getCategories(function (categories) {
	            $scope.categories = categories;
		        console.log("Categories: ", $scope.categories);
            });
			/* #endregion */

            $scope.uploadSound = function() {
                soundService.uploadSound({ soundFile: $scope.soundUpload.file });
            };

	        $scope.addCategoryToSound = function(file) {
	        	file.categories.push(file.newCategory);
	        	file.newCategory = "";
	        };

	        $scope.deleteCategoryFromSound = function(category) {
		        toastService.throwNotImplementedToast("Delete Category");
	        };

            $scope.upload = function (files) {
                console.log("upload");
                if (files && files.length) {
                    for (var i = 0; i < files.length; i++) {
                        var file = files[i];
                        $upload.upload({
                            url: 'api/Sounds/UploadSound',
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

            $scope.init = function() {
                $scope.$watch('files', function() {
                    $scope.uploadSound($scope.files);
                });
            }
        }]);