angular.module('bertha')
    .factory('momentjs', function () { return moment; })
    .filter('moment', ['momentjs', function (momentjs) {
        return function (dateString, outFormat) {
            //Handle nullable date
            if (dateString === undefined || dateString === null) {
                return '';
            }

            return momentjs(dateString).format(outFormat);
        };
    }])
    .filter('fromNow', ['momentjs', function (momentjs) {
        return function (dateString, inFormat) {
            return momentjs(dateString, inFormat).fromNow();
        };
    }]);