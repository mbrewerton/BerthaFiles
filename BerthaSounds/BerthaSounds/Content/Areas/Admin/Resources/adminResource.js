'use strict';

angular.module('bertha')
    .factory('adminFactory', [
        '$resource', function ($resource) {
            return $resource("api/Admin", {}, {
                getAllSounds: {
                    method: "GET",
                    url: "/api/Admin/GetAllSounds",
                    isArray: true
                },
                getAllCoupons: {
                    method: "GET",
                    url: "/api/Admin/GetAllCoupons",
                    isArray: true
                },
                saveCoupon: {
                    method: "POST",
                    url: "/api/Admin/SaveCoupon"
                },
                uploadSound: {
                    method: "POST",
                    url: "/api/Admin/UploadSound"
                }
            });
        }
    ]);