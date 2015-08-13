'use strict';

angular.module('bertha')
    .factory('categoryFactory', [
        '$resource', function ($resource) {
        	return $resource("api/Category", {}, {
            });
        }
    ]);