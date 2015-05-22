'use strict';

angular.module('bertha')
    .controller('couponManagementController', ['$scope', '$rootScope', '$location', '_', 'toastr', 'adminFactory',
        function ($scope, $rootScope, $location, _, toastr, adminFactory) {
            var self = this;
            console.log('>> Coupon Management Controller');

            $scope.coupons = [];
            $scope.coupon = {
                name: '',
                code: '',
                date: ''
            };

            self.getAllCoupons = function() {
                adminFactory.getAllCoupons().$promise.then(
                                function(data) {
                                    $scope.coupons = data;
                                    console.log(">> Coupons: ", $scope.coupons);
                                });
            };

            self.getAllCoupons();

            $scope.generateCoupon = function () {
                var result;
                for (var i = 0; i > 10; i++) {
                    
                }
            }

            $scope.saveCoupon = function (coupon) {
                // Date is set to null until datetimes are sorted (yay).
                coupon.date = null;
                coupon.code = coupon.code.toUpperCase();
                _.each($scope.coupons, function (item, index) {
                    var lowerCouponName = coupon.name.toLowerCase();
                    var lowerItemName = item.name.toLowerCase();
                    var upperItemCode = item.code.toUpperCase();

                    if (coupon.code === upperItemCode) {
                        toastr.error("A coupon with the code '" + coupon.code + "' already exists.");
                        return;
                    }

                    if (lowerCouponName === lowerItemName) {
                        toastr.error("A coupon with the name '" + coupon.name + "' already exists.");
                        return;
                    }
                });

                adminFactory.saveCoupon(coupon).$promise.then(
                    function (data) {
                        self.getAllCoupons();
                    });
            }

            $scope.testLog = function(item) {
                console.log(">> Item passed: ", item);
            }
        }]);