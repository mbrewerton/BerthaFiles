'use strict';

angular.module('bertha')
    .controller('categoryManagementController', ['$scope', '$rootScope', '$location', '_', "toastService", "categoryService",
        function ($scope, $rootScope, $location, _, toastService, categoryService) {
        	console.log('>> Category Management Controller');
        	$scope.categories = [];
	        $scope.newCategory = {
		        name: "",
		        description: ""
	        };

	        $scope.getCategories = function() {
		        categoryService.getCategories(function(categories) {
			        $scope.categories = categories;
		        });
	        };

	        $scope.addCategory = function(newCategory) {

		        if (newCategory.name.length === 0) {
			        toastService.error("Please enter a category name");
			        return;
		        }

		        if (newCategory.description.length === 0) {
			        toastService.error("Please enter a category description");
			        return;
		        }

		        if (_.find($scope.categories, function(ctg) {
			        return ctg.name.toLowerCase() === newCategory.name.toLowerCase();
		        })) {
			        toastService.throwDuplicateItemToast("add category with name", newCategory.name);
			        return;
		        }

		        categoryService.addCategory(newCategory.name, newCategory.description, function(category) {
			        toastService.success(category.name, "added", null);
			        $scope.categories.push(category);
		        });
	        };

	        $scope.deleteCategory = function (category) {
	        	categoryService.deleteCategory(category, function () {
	        		toastService.throwDeleteSuccessToast(category.name);
			        $scope.categories = _.without($scope.categories, category);
		        });
			}

	        $scope.init = function() {
		        $scope.getCategories();
	        }();
        }]);