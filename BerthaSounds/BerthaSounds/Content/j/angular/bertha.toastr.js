var notify = angular.module('bertha')
.factory('toastr', function () {
    return window.toastr; // assumes toastr has already been loaded on the page
});