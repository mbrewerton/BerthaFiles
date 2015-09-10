'use strict';

angular.module('bertha')
    .factory('soundFactory', [
        '$resource', function ($resource) {
        	return $resource("api/Sounds", {}, {
        		getAllSounds: {
        			method: "GET",
        			url: "/api/Sounds/GetAllSounds",
        			isArray: true
        		},
                uploadSound: {
                    method: "POST",
                    url: "/api/Sounds/UploadSound",
                    params: { file: "@file"}
                },
				addCategoryToSound: {
					method: "POST",
					url: "/api/Sounds/AddCategoryToSound",
					params: { soundId: "@soundId", categoryId: "@categoryId" }
				},
				removeCategoryFromSound: {
					method: "DELETE",
					url: "/api/Sounds/RemoveCategoryFromSound",
					params: { soundId: "@soundId", categoryId: "@categoryId" }
				},
				addTagToSound: {
					method: "POST",
					url: "/api/Sounds/AddTagToSound",
					params: { soundId: "@soundId", tagId: "@tagId" }
				},
				removeTagFromSound: {
					method: "DELETE",
					url: "/api/Sounds/RemoveTagFromSound",
					params: { soundId: "@soundId", tagId: "@tagId" }
				}
            });
        }
    ]);