'use strict';

angular.module('bertha')
    .controller('adminController', ['$scope', '$location', '_', 'adminFactory',
        function ($scope, $location, _, adminFactory) {
            console.log('>> Admin Controller');

            $scope.soundFiles = [];
            $scope.isLoadingSounds = true;

            adminFactory.getAllSounds().$promise.then(
                function (data) {
                    console.log(">> data: ", data);
                    $scope.soundFiles = data;
                    $scope.isLoadingSounds = false;
                });
        }]);