'use strict';

angular.module('bertha')
    .factory('tagFactory', [
        '$resource', function ($resource) {
        	return $resource("api/Tag", {}, {
            });
        }
    ]);