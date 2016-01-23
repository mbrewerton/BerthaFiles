'use strict';

angular.module('bertha')
    .controller('couponManagementController', ['$scope', '$rootScope', '$location', '_', 'toastService', 'couponService',
        function ($scope, $rootScope, $location, _, toastService, couponService) {
            console.log('>> Coupon Management Controller');

            $scope.coupons = [];
            $scope.coupon = {
                name: '',
                code: '',
				amount: null,
				couponType: {}
            };
            $scope.couponTypes = [];

            couponService.getCouponTypes(function (types) {
            	$scope.couponTypes = types;
	            $scope.coupon.newCouponType = types[0];
            });

	        $scope.searchData = {
		        term: "",
		        expired: false
			}

            $scope.search = function (params) {
            	if (!params)
            		params = $scope.searchData;

            	couponService.search(params.term, params.expired, function (coupons) {
            		$scope.coupons = coupons;
            	});
            };

            $scope.sortField = "Id";
	        $scope.sortReverse = false;
            $scope.setSortField = function (sortField) {
            	$scope.sortField = sortField;
            	$scope.sortReverse = !$scope.sortReverse;
            };

	        $scope.generateCoupon = function() {
	        	var text = "";
	        	var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

	        	for (var i = 0; i < 10; i++)
	        		text += possible.charAt(Math.floor(Math.random() * possible.length));

		        $scope.coupon.newCode = text;
	        };

	        $scope.toggleEditCoupon = function (coupon) {
				coupon.newName = coupon.name;
				coupon.newCode = coupon.code;
				coupon.newCouponType = coupon.couponType;
		        coupon.newAmount = coupon.amount;
	        	coupon.newStartDate = coupon.startDate;
	        	coupon.newEndDate = coupon.endDate;
		        coupon.isEditing = !coupon.isEditing;
	        };

	        $scope.toggleExpired = function() {
	        };

	        $scope.saveCoupon = function (coupon) {
	        	coupon.name = coupon.newName;
	        	coupon.code = coupon.newCode.toUpperCase();
	        	coupon.couponType = coupon.newCouponType;
		        coupon.amount = coupon.newAmount;
	        	coupon.startDate = coupon.newStartDate;
	        	coupon.endDate = coupon.newEndDate;

		        if (coupon.name.length === 0) {
			        toastService.error("Please enter a coupon name");
			        return;
		        }

		        if (coupon.code.length === 0) {
			        toastService.error("Please enter a coupon code.");
			        return;
		        }

		        if (!coupon.startDate) {
			        toastService.error("Please enter a start date.");
			        return;
		        }

		        if (_.find($scope.coupons, function(cpn) {
			        return cpn.name.toLowerCase() === coupon.name.toLowerCase();
		        })) {
			        toastService.throwDuplicateItemToast("add coupon with name", coupon.name);
			        return;
		        }

		        if (_.find($scope.coupons, function (cpn) {
			        return cpn.code.toLowerCase() === coupon.code.toLowerCase();
		        })) {
			        toastService.throwDuplicateItemToast("add coupon with code", coupon.code);
			        return;
		        }

		        couponService.addCoupon(coupon, function(data) {
			        $scope.search();
		        });
	        };

	        $scope.deleteCoupon = function (coupon) {
		        couponService.deleteCoupon(coupon, function() {
		        	toastService.throwDeleteSuccessToast(coupon.name);
			        $scope.coupons = _.without($scope.coupons, coupon);
		        });
	        };

	        $scope.init = function() {
	        	$scope.search();
	        }();
        }]);