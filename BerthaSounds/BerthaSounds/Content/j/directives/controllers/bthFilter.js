'use strict';

angular.module("bertha")
	.directive("bthFilter", function() {
		var controller = [
			"$scope", "toastService", "categoryService", "tagService",
			function ($scope, toastService, categoryService, tagService) {
			    $scope.categoryToAdd = "";
			    $scope.resetFilter = function () {
			        $scope.filterRoot = {
			            categories: [],
			            tags: []
			        };
			    };

			    $scope.getCategories = function (term) {
			        return categoryService.search(term, function (categories) {
			            return categories;
			        });
			    };

			    $scope.getTags = function (term) {
			        return tagService.search(term, function (tags) {
			            return tags;
			        });
			    };

			    $scope.toggleAddNewCategoryFilter = function () {
			        $scope.filterRoot.addNewCategory = !$scope.filterRoot.addNewCategory;
			    };

			    $scope.toggleAddNewTagFilter = function () {
			        $scope.filterRoot.addNewTag = !$scope.filterRoot.addNewTag;
			    };

			    $scope.addCategoryToFilter = function (category) {
			        var exists = _.find($scope.filterRoot.categories, category);
			        if (exists) {
			            toastService.throwDuplicateItemToast("add", category.name);
			            $scope.filterRoot.categoryToAdd = "";
			            return;
			        }
			        $scope.filterRoot.categories.push(category);
			        $scope.filterRoot.categoryToAdd = "";
			    };

			    $scope.addTagToFilter = function (tag) {
			        var exists = _.find($scope.filterRoot.tags, tag);
			        if (exists) {
			            toastService.throwDuplicateItemToast("add", tag.name);
			            $scope.filterRoot.tagToAdd = "";
			            return;
			        }
			        $scope.filterRoot.tags.push(tag);
			        $scope.filterRoot.tagToAdd = "";
			    };

			    $scope.init = function () {
			        $scope.resetFilter();
					$scope.loading = true;
					$scope.$watch("sounds", function(sounds) {
						if (sounds != undefined)
							$scope.loading = false;
					});
				}();
			}
	];

	return {
		restrict: "E",
		scope: {
			sounds: "="
		},
		templateUrl: "Content/j/directives/templates/bthFilter.html",
		controller: controller
	};
});