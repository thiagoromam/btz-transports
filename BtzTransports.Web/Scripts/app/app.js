(function () {
    var app = angular.module("app", ["api"]);

    app.run(["$rootScope", function (rootScope) {
        rootScope.Enum = window.Enum;
    }]);
    
    app.config(["$httpProvider", function (provider) {

        function parseJsonResponse(data) {
            if (/^\d{4}(?:\-\d{2}){2}T\d{2}(?:\:\d{2}){2}/.test(data)) {
                return new Date(Date.parse(data));
            }

            if (data instanceof Object) {
                Object.getOwnPropertyNames(data).forEach(key => {
                    data[key] = parseJsonResponse(data[key]);
                });
            }

            return data;
        }

        provider.interceptors.push(function () {
            return {
                response: function (r) {
                    if (r.data) {
                        r.data = parseJsonResponse(r.data);
                    }

                    return r;
                }
            };
        });
    }]);
})();