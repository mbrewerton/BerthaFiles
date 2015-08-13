'use strict';

angular.module('bertha')
    .controller('couponManagementController', ['$scope', '$rootScope', '$location', '_', 'toastr',
        function ($scope, $rootScope, $location, _, toastr) {
            //var self = this;
            console.log('>> Coupon Management Controller');

            //$scope.coupons = [];
            //$scope.coupon = {
            //    name: '',
            //    code: ''
            //};

            //self.getAllCoupons = function() {
            //    adminFactory.getAllCoupons().$promise.then(
            //                    function(data) {
            //                        $scope.coupons = data;
            //                        console.log(">> Coupons: ", $scope.coupons);
            //                    });
            //};

            //self.getAllCoupons();

            //$scope.generateCoupon = function () {
            //    $scope.coupon.code =  "TESTCOUPON";
            //}

            //$scope.saveCoupon = function (coupon) {
            //    coupon.code = coupon.code.toUpperCase();
            //    _.each($scope.coupons, function (cpn, index) {
            //        var lowerCouponName = coupon.name.toLowerCase();
            //        var lowerItemName = cpn.name.toLowerCase();
            //        var upperItemCode = cpn.code.toUpperCase();

            //        if (coupon.code === upperItemCode) {
            //            toastr.error("A coupon with the code '" + coupon.code + "' already exists.");
            //            return;
            //        }

            //        if (lowerCouponName === lowerItemName) {
            //            toastr.error("A coupon with the name '" + coupon.name + "' already exists.");
            //            return;
            //        }
            //    });

            //    adminFactory.saveCoupon(coupon).$promise.then(
            //        function (data) {
            //            self.getAllCoupons();
            //        });
            //}
        }]);