'use strict';

angular.module('bertha')
    .factory('couponFactory', [
        '$resource', function ($resource) {
        	return $resource("api/Coupons", {}, {
				getCoupons: {
					method: "GET",
					url: "api/Coupons/GetCoupons",
					isArray: true
				},
        		addCoupon: {
        			method: "POST",
        			url: "api/Coupons/AddCoupon"
        		},
        		deleteCoupon: {
        			method: "DELETE",
        			url: "api/Coupons/DeleteCoupon"
        		}
            });
        }
    ]);