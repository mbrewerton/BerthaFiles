'use strict';
angular.module("bertha")
	.factory("toastService", [
		"toastr",
		function(toastr) {
			var service = {
				success: function(item, func, title, callback) {
					var msg = item + " " + func + " successfully!";
					var msgTitle = title ? title : "Success!";

					toastr.success(msg, msgTitle, callback);
				},
				error: function(message, title, callback) {
					var msgTitle = title ? title : "Error";
					console.log("Error Message: ", message);
					toastr.error(message, msgTitle, callback);
				},
				warning: function(message, title, callback) {
					var msgTitle = title ? title : "Warning";
					toastr.warning(message, msgTitle, callback);
				},
				throwSuccessfulToast: function(func, title, callback) {
					var msg = func + " was successful.";
					service.success(msg, title, callback);
				},
				throwDuplicateItemToast: function(func, item, title, callback) {
					var msg = "Cannot " + func + " ";
					if (item)
						msg += item + " ";
					msg += "as it already exists.";

					service.error(msg, title, callback);
				},
				throwItemInUseToast: function(func, item, inUseOn, title, callback) {
					var msg = "Cannot " + func + " " + item + " as it is currently in use";

					if (inUseOn)
						msg += " on a " + inUseOn + ".";
					else
						msg += ".";

					service.error(msg, title, callback);
				},
				throwDeleteSuccessToast: function(item, title, callback) {
					var func = "deleted";
					service.success(item, func, title, callback);
				},
				throwUnexpectedErrorToast: function(rejection) {
					service.error("Sorry, there was an unexpected error carrying out that action.");
				},
				throwUnexpectedConflictToast: function (rejection) {
					if (rejection.data !== "") {
						service.error(rejection.Message);
					} else {
						service.error("Sorry, an unexpected conflict has occured occurred.");
					}
				},
				throwInsufficientPermissionsToast: function(rejection) {
					service.error("Sorry, You do not have permission to carry out that action.");
				},
				throwBadRequestToast: function (rejection) {
					console.log("The reject: ", rejection);	
					service.error(rejection.Message);
				},
				throwNotImplementedToast: function(item) {
					var defaultMsg = "Not Yet Implemented.";
					var msg = item ? item + " " + defaultMsg : defaultMsg;

					service.warning(msg, defaultMsg);
				}
		};

			return service;
		}
	]);