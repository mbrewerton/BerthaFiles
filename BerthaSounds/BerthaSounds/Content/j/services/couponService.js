'use strict';
angular.module("bertha")
	.factory("couponService", [
		"couponFactory",
		function (couponFactory) {
			var service = {
				getCoupons: function(getExpired, callback) {
					return couponFactory.getCoupons({ expired: getExpired }).$promise.then(callback);
				},
				addCoupon: function(coupon, callback) {
					return couponFactory.addCoupon(coupon).$promise.then(callback);
				},
				deleteCoupon: function(coupon, callback) {
					return couponFactory.deleteCoupon({ id: coupon.id }).$promise.then(callback);
				}
			};

			return service;
		}
	]);