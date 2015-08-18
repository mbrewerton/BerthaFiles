//This defines the angular application, angular uses DI, if you need additional modules add them between the braces []
//Make sure you have the correct additional angular JS files for any additional modules you use
var appName = 'bertha';
angular.module(appName, [
    'ngRoute',
    'ngResource',
    'angularFileUpload'
]);

//Configure route provider for HTML5 mode
angular.module(appName)
    .config(['$routeProvider', '$locationProvider', '$httpProvider', '$provide', function ($routeProvider, $locationProvider, $httpProvider, $provide) {
    	console.log(">> Initialised");

    	$locationProvider.html5Mode(true);

    	$provide.factory("errorInterceptor", [
			"$q", "toastService", function ($q, toastService) {
				return {
					'responseError': function (rejection) {
						// do something on error
						var status = rejection.status;
						if (status == 400) {
							toastService.throwBadRequestToast(rejection);
						}
						if (status == 403 || status == 401) {
							toastService.throwInsufficientPermissionsToast(rejection);
						}
						if (status == 500) {
							toastService.throwUnexpectedErrorToast(rejection);
						}
						return $q.reject(rejection);
					}
				};
			}
    	]);

    	$httpProvider.interceptors.push("errorInterceptor");
    }]);


//Lib setup here - only use JS that has been defined as factories, then use via angular DI
//JQuery
angular.module(appName)
   .factory('$', function () { return $; });