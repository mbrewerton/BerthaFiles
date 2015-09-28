'use strict';

angular.module('bertha')
    .factory('lookupsFactory', [
        '$resource', function () {
        	var lookupsFactory = {};

        	lookupsFactory.couponTypes = [
				{ id: 1, name: "BasketTotalPercent", title: "Basket %" },
				{ id: 2, name: "BasketTotalAmount", title: "Basket Total" }
        	];

			return lookupsFactory;
		}
    ]);