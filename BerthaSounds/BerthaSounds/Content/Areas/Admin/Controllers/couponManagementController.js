'use strict';

angular.module('bertha')
    .controller('couponManagementController', ['$scope', '$rootScope', '$location', '_', 'toastService', 'couponService',
        function ($scope, $rootScope, $location, _, toastService, couponService) {
            console.log('>> Coupon Management Controller');

            $scope.coupons = [];
            $scope.coupon = {
                name: '',
                code: ''
            };

            $scope.getAllCoupons = function() {
	            couponService.getCoupons(function(data) {
		            $scope.coupons = data;
	            });
            };

            $scope.generateCoupon = function () {
                $scope.coupon.code =  "TESTCOUPON";
            }

            $scope.saveCoupon = function(coupon) {
		        coupon.code = coupon.code.toUpperCase();

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
					}))
		        {
		        	toastService.throwDuplicateItemToast("add coupon with name", coupon.name);
			        return;
		        }

		        if (_.find($scope.coupons, function(cpn) {
						return cpn.code.toLowerCase() === coupon.code.toLowerCase();
					}))
		        {
		        	toastService.throwDuplicateItemToast("add coupon with code", coupon.code);
			        return;
		        }

	            couponService.addCoupon(coupon, function(data) {
		            $scope.getAllCoupons();
	            });
            }

	        $scope.init = function() {
		        $scope.getAllCoupons();
	        }();
        }]);