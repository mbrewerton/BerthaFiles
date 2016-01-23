'use strict';

angular.module('bertha')
    .factory('couponFactory', [
        '$resource', function ($resource) {
        	return $resource("api/Coupons", {}, {
				search: {
					method: "GET",
					url: "/api/Coupons/Search",
					params: { expired: "@expired" },
					isArray: true
				},
        		addCoupon: {
        			method: "POST",
        			url: "/api/Coupons/AddCoupon"
        		},
        		deleteCoupon: {
        			method: "DELETE",
        			url: "/api/Coupons/DeleteCoupon"
        		},
				getCouponTypes: {
					method: "GET",
					url: "/api/coupons/GetCouponTypes",
					isArray: true
				}
            });
        }
    ]);