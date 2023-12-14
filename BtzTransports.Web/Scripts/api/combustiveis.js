(function () {
    var api = angular.module("api");

    api.resource("combustiveis", ["$http", function (http) {
        var uri = "/api/combustiveis";

        this.listar = function () {
            return http.get(uri);
        };
    }]);
})();