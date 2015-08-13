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
				}
			};

			return service;
		}
	]);