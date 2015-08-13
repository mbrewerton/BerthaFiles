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
	        	categoryService.addCategory(newCategory.name, newCategory.description, function (category) {
	        		toastService.success(category.name, "added", null);
			        $scope.categories.push(category);
		        });
	        }

	        $scope.init = function() {
		        $scope.getCategories();
	        }();
        }]);