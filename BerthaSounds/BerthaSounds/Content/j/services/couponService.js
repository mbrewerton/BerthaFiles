﻿'use strict';
angular.module("bertha")
	.factory("couponService", [
		"couponFactory",
		function (couponFactory) {
			var service = {
				getCoupons: function(callback) {
					return couponFactory.getCoupons().$promise.then(callback);
				},
				addCoupon: function(coupon, callback) {
					return couponFactory.addCoupon(coupon).$promise.then(callback);
				}
			};

			return service;
		}
	]);