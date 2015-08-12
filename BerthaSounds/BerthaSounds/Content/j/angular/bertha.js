//This defines the angular application, angular uses DI, if you need additional modules add them between the braces []
//Make sure you have the correct additional angular JS files for any additional modules you use
angular.module('bertha', [
    'ngRoute',
    'ngResource',
    'angularFileUpload'
]);

//Configure route provider for HTML5 mode
angular.module('bertha')
    .config(['$routeProvider', '$locationProvider', '$httpProvider', '$provide', function ($routeProvider, $locationProvider, $httpProvider, $provide) {
        console.log(">> Initialised");
    }]);


//Lib setup here - only use JS that has been defined as factories, then use via angular DI
//JQuery
angular.module('bertha')
   .factory('$', function () { return $; });