'use strict';

angular.module('bertha')
    .controller('soundManagementController', ['$scope', '$rootScope', '$location', '$upload', '_', 'soundFactory',
        function ($scope, $rootScope, $location, $upload, _, soundFactory) {
            console.log("$upload ", $upload);

            console.log('>> Sound Management Controller');

            soundFactory.getAllSounds().$promise.then(
                function (data) {
                    $scope.soundFiles = data;
                    $scope.isLoadingSounds = false;
                });

            $scope.uploadSound = function() {
                soundFactory.uploadSound({ soundFile: $scope.soundUpload.file });
            };

            $scope.upload = function (files) {
                console.log("upload");
                if (files && files.length) {
                    for (var i = 0; i < files.length; i++) {
                        var file = files[i];
                        $upload.upload({
                            url: 'api/Sounds/UploadSound',
                            file: file
                        }).progress(function(evt) {
                            var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                            console.log('progress: ' + progressPercentage + '% ' + evt.config.file.name);
                        }).success(function(data, status, headers, config) {
                            console.log('file ' + config.file.name + 'uploaded. Response: ' + data);
                        }).error(function(data, status, headers, config) {
                            console.log('error status: ' + status);
                        });
                    }
                }
            };

            $scope.init = function() {
                $scope.$watch('files', function() {
                    $scope.uploadSound($scope.files);
                });
            }
        }]);