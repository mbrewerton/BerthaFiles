'use strict';
angular.module("bertha")
	.factory("toastService", [
		"toastr",
		function(toastr) {
			var service = {
			success: function(item, func, title, callback) {
					var msg = item + " " + func + " successfully!";
					var msgTitle = title ? title : "Success!";

					toastr.success(msg, msgTitle);

					if (callback)
						callback();
				},
			error: function(message, callback) {
				toastr.error(message, callback);
			},
			warning: function(message, callback) {
				toastr.warning(message, callback);
			},
			throwSuccessfulToast: function (func, callback) {
				var msg = func + " was successful.";
				toastr.success(msg);

				if (callback)
					callback();
			},
			throwDuplicateItemToast: function(func, item, callback) {
				var msg = "Cannot " + func + " ";
				if (item)
					msg += item + " ";
				msg += "as it already exists.";
				toastr.error(msg);

				if (callback)
					callback();
			},
			throwItemInUseToast: function (func, item, inUseOn, callback) {
				var msg = "Cannot " + func + " " + item + " as it is currently in use";

				if (inUseOn)
					msg += " on a " + inUseOn + ".";
				else
					msg += ".";

				toastr.error(msg);	

				if (callback)
					callback();
			},
			throwDeleteSuccessToast: function(item, callback) {
				var msg = item + " was deleted successfully.";
				toastr.success(msg);

				if (callback)
					callback();
			},
			throwUnexpectedErrorToast: function(rejection) {
				toastr.error("Sorry, there was an unexpected error carrying out that action.");
				console.log("Rejected: ", rejection);
			},
			throwInsufficientPermissionsToast: function(rejection) {
				toastr.error("Sorry, You do not have permission to carry out that action.");
				console.log("Rejected: ", rejection);
			},
			throwBadRequestToast: function(rejection) {
				toastr.error(rejection.data);
				console.log("Rejected: ", rejection);
			},
			throwNotImplementedToast: function(item) {
				var defaultMsg = "Not Yet Implemented.";
				var msg = item ? item + " " + defaultMsg : defaultMsg;

				toastr.warning(msg, defaultMsg);
			}
			};

			return service;
		}
	]);