'use strict';
angular.module("bertha")
	.factory("couponService", [
		"couponFactory",
		function (couponFactory) {
			var service = {
				search: function(term, getExpired, callback) {
					return couponFactory.search({ term: term, expired: getExpired }).$promise.then(callback);
				},
				addCoupon: function(coupon, callback) {
					return couponFactory.addCoupon(coupon).$promise.then(callback);
				},
				deleteCoupon: function(coupon, callback) {
					return couponFactory.deleteCoupon({ id: coupon.id }).$promise.then(callback);
				},
				getCouponTypes: function (callback) {
					return couponFactory.getCouponTypes().$promise.then(callback);
				}
			};

			return service;
		}
	]);