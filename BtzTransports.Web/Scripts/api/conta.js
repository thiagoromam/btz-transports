(function () {
    var api = angular.module("api");

    api.resource("conta", ["$http", function (http) {

        this.login = function (dados) {
            return http.post("/api/conta/login", dados);
        };
    }]);
})();