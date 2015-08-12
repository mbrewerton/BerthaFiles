'use strict';

angular.module('bertha')
    .controller('adminController', ['$scope', '$location', '_', 'soundFactory',
        function ($scope, $location, _, soundFactory) {
            console.log('>> Admin Controller');

            $scope.soundFiles = [];
            $scope.isLoadingSounds = true;

            soundFactory.getAllSounds().$promise.then(
                function (data) {
                    console.log(">> data: ", data);
                    $scope.soundFiles = data;
                    $scope.isLoadingSounds = false;
                });
        }]);