'use strict';

angular.module('bertha')
    .controller('soundManagementController', ['$scope', '$rootScope', '$location', '_', 'adminFactory',
        function ($scope, $rootScope, $location, _, adminFactory) {
            $scope.soundUpload = {};
            $scope.soundUpload.file = '';
            $scope.soundFiles = [];
            $scope.isLoadingSounds = true;

            console.log('>> Sound Management Controller');

            adminFactory.getAllSounds().$promise.then(
                function (data) {
                    console.log(">> data: ", data);
                    $scope.soundFiles = data;
                    $scope.isLoadingSounds = false;
                });

            $scope.uploadSound = function() {
                adminFactory.uploadSound($scope.soundUpload.file);
            };
        }]);