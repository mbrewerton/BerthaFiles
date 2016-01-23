'use strict';

angular.module('bertha')
    .controller('soundController', ['$scope', '$location', '_', 'soundService',
        function ($scope, $location, _, soundService) {
            console.log(">> Sound Controller");

            $scope.init = function () {

            }();
        }]);